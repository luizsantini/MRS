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
                Contact = new OpenApiContact() { Name = "Luiz Santini", Email = "luizsantini.dev@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });
        });
    }

    public static void UseSwaggerConfig(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) return;
        
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }
}