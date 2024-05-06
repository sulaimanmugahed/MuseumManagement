using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Infrastructure.Resources.Services;

namespace MuseumManagement.Infrastructure.Resources
{
    public static class ServiceRegistration
    {
        public static void AddResourcesInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.AddSingleton<ITranslator, Translator>();
        }
    }
}
