using Application.UnitOfWork;
using Domain.Interfaces;

namespace ApiUniversidad.Extensions;

public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()   
            .AllowAnyMethod()      
            .AllowAnyHeader());     
    });

    public static void AddAplicacionServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>(); 
    }
}