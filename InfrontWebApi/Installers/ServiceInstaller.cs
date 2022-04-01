using Infront.Services.IServices;
using Infront.Services.Provider.Cache;
using Infront.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infront.Api.Installers
{
    public class ServiceInstaller : IInstaller
    {

        public IServiceCollection InstallServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, CachedUserService>();
            services.AddScoped<ICacheProvider, CacheProvider>();
            services.AddScoped<UserService>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddHttpClient();
            return services;
        }
    }
}
