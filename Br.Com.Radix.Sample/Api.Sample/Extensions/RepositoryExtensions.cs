using Data.Core.Repositories;
using Domain.Core.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Sample.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositoryInjections(this IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            return services;
        }
    }
}
