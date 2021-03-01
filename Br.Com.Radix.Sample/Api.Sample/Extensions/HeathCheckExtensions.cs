using Api.Sample.Extensions.HealthChecks;
using Data.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Sample.Extensions
{
    public static class HeathCheckExtensions
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddDbCheck<CoreContext>();

            return services;
        }

        private static IHealthChecksBuilder AddDbCheck<T>(this IHealthChecksBuilder builder)
            where T : DbContext
            => builder.AddCheck<DbConnectionHealthCheck<T>>(typeof(T).Name);
    }
}
