using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Repositories;
using WarnerMedia.Repositories.Interfaces;

namespace WarnerMedia.Installer
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<ICreditRepository, CreditRepository>();
        }
    }
}
