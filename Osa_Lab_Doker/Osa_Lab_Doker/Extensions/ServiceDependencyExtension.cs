using Microsoft.EntityFrameworkCore;
using Osa_Lab_Doker.Common.Interfaces;
using Osa_Lab_Doker.Data;
using Osa_Lab_Doker.Services;

namespace Osa_Lab_Doker.Extensions;

public static class ServiceDependencyExtension
{
    /// <summary>
    /// Add service dependencies
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddBackendServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BackendDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("osa-lab-db")));

        services.AddScoped<INoteService, NoteService>();
        return services;
    }
}
