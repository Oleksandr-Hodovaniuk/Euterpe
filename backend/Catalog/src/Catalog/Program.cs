using Catalog;
using Catalog.Application;
using Catalog.Extensions;
using Catalog.Infrastructure;
using Catalog.Middlewares;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../../../../.env");
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services
    .AddApiServices()
    .AddInfrastructureServices()
    .AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionHandlingMiddleware>();

await app.InitialiseDatabaseAsync();

app.UseSwaggerDocumentation(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
