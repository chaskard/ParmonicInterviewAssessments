using Ledger.api.Services;
using Ledger.Domain.Entities;
using Ledger.Domain.Interfaces;
using Ledger.Infrastucture;
using Ledger.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Ledger.api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
                .AddScoped<IBusinessOwnerRepository, BusinessOwnerRepository>();
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<EFContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DDDConnectionString")));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services
           )
        {
            return services
                .AddScoped<ILedgerService, LedgerService>();
        }
    }
}
