using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Domain.Settings;
using MuseumManagement.Infrastructure.FileManager.Services;
using System;
using System.IO;

namespace MuseumManagement.Infrastructure.FileManager
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddFileManagerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<FileManagerDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("FileManagerConnection"));
            //});
            services.AddScoped<IFileManagerService, FileManagerService>();
         
            return services;

        }
    }
}