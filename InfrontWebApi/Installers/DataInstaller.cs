using Infront.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infront.Api.Installers
{
    public class DataInstaller : IInstaller
    {
        public IServiceCollection InstallServices(IServiceCollection services)
        {
            services.AddScoped<IHttpClient, HttpClient>();

            return services;
        }
    }
}
