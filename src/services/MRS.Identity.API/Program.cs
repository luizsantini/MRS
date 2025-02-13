using MRS.Identity.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddApiConfig(configuration);
services.AddSwaggerConfig();
services.AddJwtConfig(configuration);

var app = builder.Build();

app.UseApiConfig(app.Environment);
app.UseSwaggerConfig(app.Environment);

app.Run();