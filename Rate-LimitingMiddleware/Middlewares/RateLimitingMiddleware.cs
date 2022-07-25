using AspNetCoreRateLimit;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Net;

namespace Rate_LimitingMiddleware.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _cache;
        private readonly IpRateLimitPolicies _ipRateLimitPolicies ;

        public RateLimitingMiddleware(RequestDelegate next, IDistributedCache cache, IOptions<IpRateLimitPolicies> ipRateLimitPolicies)
        {
            _next = next;
            _cache = cache;
            _ipRateLimitPolicies = ipRateLimitPolicies.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            

            var remoteIp = context.Connection.RemoteIpAddress;

            if (remoteIp is null)
            {
                await _next(context);
                return;
            }

            var filteredIP = _ipRateLimitPolicies.IpRules.FirstOrDefault(a => a.Ip == remoteIp.ToString());

            if (filteredIP is not null)
            foreach (var rule in filteredIP.Rules)
            {
                var key = GenerateClientKey(context);
                var clientStatistics = await GetClientStatisticsByKey(key);

                if (clientStatistics != null && DateTime.UtcNow < clientStatistics.LastSuccessfulResponseTime.AddSeconds(ToTimeSpan(rule.Period)) && clientStatistics.NumberOfRequestsCompletedSuccessfully == rule.Limit)
                {
                    context.Response.Headers["Retry-After"] = clientStatistics.LastSuccessfulResponseTime.AddSeconds(ToTimeSpan(rule.Period)).ToString() + "sec";
                    context.Response.ContentType = "application/json";
                   context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    return;
                }

                await UpdateClientStatisticsStorage(key, Convert.ToInt16(rule.Limit));
            }
            
            await _next(context);
        }

        private static string GenerateClientKey(HttpContext context) => $"{context.Request.Path}_{context.Connection.RemoteIpAddress}";

        private async Task<ClientStatistics> GetClientStatisticsByKey(string key) => await _cache.GetCacheValueAsync<ClientStatistics>(key);

        private async Task UpdateClientStatisticsStorage(string key, int maxRequests)
        {
            var clientStat = await _cache.GetCacheValueAsync<ClientStatistics>(key);

            if (clientStat != null)
            {
                clientStat.LastSuccessfulResponseTime = DateTime.UtcNow;

                if (clientStat.NumberOfRequestsCompletedSuccessfully == maxRequests)
                    clientStat.NumberOfRequestsCompletedSuccessfully = 1;

                else
                    clientStat.NumberOfRequestsCompletedSuccessfully++;

                await _cache.SetCahceValueAsync<ClientStatistics>(key, clientStat);
            }
            else
            {
                var clientStatistics = new ClientStatistics
                {
                    LastSuccessfulResponseTime = DateTime.UtcNow,
                    NumberOfRequestsCompletedSuccessfully = 1
                };

                await _cache.SetCahceValueAsync<ClientStatistics>(key, clientStatistics);
            }

        }
        private int ToTimeSpan(string timeSpan)
        {
            var l = timeSpan.Length - 1;
            var value = timeSpan.Substring(0, l);
            var type = timeSpan.Substring(l, 1);

            return type switch
            {
                "d" => TimeSpan.FromDays(double.Parse(value)).Seconds,
                "h" => TimeSpan.FromHours(double.Parse(value)).Seconds,
                "m" => TimeSpan.FromMinutes(double.Parse(value)).Seconds,
                "s" => TimeSpan.FromSeconds(double.Parse(value)).Seconds,
                _ => throw new FormatException($"{timeSpan} can't be converted to TimeSpan, unknown type {type}"),
            };
        }
    }

}
