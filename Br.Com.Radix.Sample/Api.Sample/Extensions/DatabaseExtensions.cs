using Data.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Sample.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = Environment.GetEnvironmentVariable("ConnectionString") ?? configuration.GetConnectionString("CoreContext");
            services.AddDbContextPool<CoreContext>(options =>
                options.UseNpgsql(connection));
            return services;
        }
    }
}
