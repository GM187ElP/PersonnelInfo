using Autofac;
using Autofac.Extensions.DependencyInjection;
using PersonnelInfo.Infrastructure.Configuration;
using PersonnelInfo.Application;  // Add your interface references

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register Autofac modules and services
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ProjectModule()); // Your Autofac module (e.g. ProjectModule)
});

// Register OpenAPI
builder.Services.AddOpenApi();

// Add any other necessary services (e.g. logging, authentication)
builder.Services.AddLogging();
builder.Services.AddAuthentication();

// Add the middleware manually
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/openapi/v1.json", "PersonnelInfo");
    });
}

// 1. Global exception handling middleware (at the beginning)
app.UseMiddleware<GlobalExceptionMiddleware>();

// 2. Encryption/Decryption middleware (after exception handling)
app.UseMiddleware<EncryptDecryptIdMiddleware>();

// 3. Standard middleware (HTTPS, Authorization, etc.)
app.UseHttpsRedirection();
app.UseAuthorization();

// 4. Map controllers after all other middleware
app.MapControllers();

app.Run();
