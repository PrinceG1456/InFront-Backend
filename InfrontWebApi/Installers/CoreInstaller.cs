using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infront.Api.Installers
{
    public class CoreInstaller : IInstaller
    {
        public IServiceCollection InstallServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddMemoryCache();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Infront Web API",
                    Description = "Infront Web API"
                });
            });

            return services;
        }
    }
}
