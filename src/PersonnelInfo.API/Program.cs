using Autofac;
using Autofac.Extensions.DependencyInjection;
using PersonnelInfo.Infrastructure.Configuration;
using PersonnelInfo.Application;
using PersonnelInfo.API.Models;  

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ProjectModule()); 
});

builder.Services.AddOpenApi();

builder.Services.AddLogging();
builder.Services.AddAuthentication();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(o =>
    {
        o.SwaggerEndpoint("/swagger/v1/swagger.json", "PersonnelInfo");
    });

    app.MapOpenApi(); 
}

app.UseMiddleware<GlobalExceptionMiddleware>();


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
