using Catalog;
using Catalog.Extensions;
using Catalog.Infrastructure;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load("../../../../.env");
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services
    .AddApiServices()
    .AddInfrastructureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

await app.InitialiseDatabaseAsync();

app.UseSwaggerDocumentation(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
