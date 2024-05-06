using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using MuseumManagement.Infrastructure.Persistence.Repositories;
using System.Linq;
using System.Reflection;

namespace MuseumManagement.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
           options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.RegisterRepositories();

        }
        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericEntityRepository<,>), typeof(GenericEntityRepository<,>));

            var interfaceType = typeof(IGenericEntityRepository<,>);
            var interfaces = Assembly.GetAssembly(interfaceType).GetTypes()
                .Where(p => p.GetInterface(interfaceType.Name.ToString()) != null);

            foreach (var item in interfaces)
            {
                var implimentation = Assembly.GetAssembly(typeof(GenericEntityRepository<,>)).GetTypes()
                    .FirstOrDefault(p => p.GetInterface(item.Name.ToString()) != null);
                services.AddTransient(item, implimentation);

            }

        }
    }
}
