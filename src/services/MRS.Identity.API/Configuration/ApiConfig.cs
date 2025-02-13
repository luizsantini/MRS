using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MRS.Identity.API.Data;

namespace MRS.Identity.API.Configuration;

public static class ApiConfig
{
    public static void AddApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine)
                .EnableDetailedErrors());
        
        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddControllers();
    }

    public static void UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
        
        // app.UseHttpsRedirection();
        
        app.UseRouting();
        
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}