using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WarnerMedia.Installer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
