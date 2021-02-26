using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace Api.Sample.Extensions
{
    /// <summary>
    /// Extensões de configuração do swagger
    /// </summary>
    public static class SwaggerExtensions
    {

        /// <summary>
        /// Configurações instação do swagger no projeto
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Radix",
                        Version = "v1",
                        Description = "Api para gerenciamento de eventos sensoriais.",
                        Contact = new OpenApiContact
                        {
                            Name = "Cristiano Macedo",
                            Url = new Uri("https://github.com/cristianomg")
                        }
                    });
            });
            return services;
        }
    }
}
