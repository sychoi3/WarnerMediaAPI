using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Services;
using WarnerMedia.Services.Interfaces;

namespace WarnerMedia.Installer
{
    public class AppServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITitleService, TitleService>();
            services.AddScoped<ICreditService, CreditService>();
        }
    }
}
