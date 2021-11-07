using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarnerMedia.Domain.Entities;

namespace WarnerMedia.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = new SqlConnectionStringBuilder(configuration.GetConnectionString("TitleDatabase"));

            services.AddDbContext<TitlesContext>((sp, builder) =>
            {
#if DEBUG
                builder.EnableSensitiveDataLogging();
                builder.EnableDetailedErrors();
#endif
                builder.UseSqlServer(connectionString.ToString());
            });
        }
    }
}
