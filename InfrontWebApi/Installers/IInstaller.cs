using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infront.Api.Installers
{
    public interface IInstaller
    {
        IServiceCollection InstallServices(IServiceCollection services);
    }
}
