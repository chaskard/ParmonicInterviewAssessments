namespace Rate_LimitingMiddleware.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRateLimiting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RateLimitingMiddleware>();
        }
    }
}
