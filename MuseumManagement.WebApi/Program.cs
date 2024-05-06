using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MuseumManagement.Application;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Infrastructure.FileManager;
using MuseumManagement.Infrastructure.Identity;
using MuseumManagement.Infrastructure.Identity.Contexts;
using MuseumManagement.Infrastructure.Identity.Models;
using MuseumManagement.Infrastructure.Identity.Seeds;
using MuseumManagement.Infrastructure.Persistence;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using MuseumManagement.Infrastructure.Persistence.Seeds;
using MuseumManagement.Infrastructure.Resources;
using MuseumManagement.WebApi.Infrastracture.Extensions;
using MuseumManagement.WebApi.Infrastracture.Middlewares;
using MuseumManagement.WebApi.Infrastracture.Services;
using Serilog;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddFileManagerInfrastructure(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddResourcesInfrastructure(builder.Configuration);

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddJwt(builder.Configuration);

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.AddSwaggerWithVersioning();
builder.Services.AddCors(x =>
{
    x.AddPolicy("Any", b =>
    {
        b.AllowAnyOrigin();
        b.AllowAnyHeader();
        b.AllowAnyMethod();

    });
});

builder.Services.AddCustomLocalization(builder.Configuration);

builder.Services.AddHealthChecks();
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<IdentityContext>().Database.MigrateAsync();
    await services.GetRequiredService<ApplicationDbContext>().Database.MigrateAsync();

    //Seed Data
    await DefaultData.SeedAsync(services.GetRequiredService<ApplicationDbContext>());
    await DefaultRoles.SeedAsync(services.GetRequiredService<RoleManager<ApplicationRole>>());
    await DefaultBasicUser.SeedAsync(services.GetRequiredService<UserManager<ApplicationUser>>());

}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MuseumManagement.WebApi v1"));
}

app.UseStaticFiles();



app.UseCustomLocalization();
app.UseCors("Any");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerWithVersioning();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHealthChecks("/health");

app.MapControllers();
app.UseSerilogRequestLogging();

app.Run();