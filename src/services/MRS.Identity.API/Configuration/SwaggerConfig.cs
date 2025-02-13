using Microsoft.OpenApi.Models;

namespace MRS.Identity.API.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Identity API",
                Description = "An Authentication API for Movie Reservation System App",
            });
        });
    }
}