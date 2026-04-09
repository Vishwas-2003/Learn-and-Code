using LocationGeocoding.Console.Application;
using LocationGeocoding.Console.Infrastructure;
using LocationGeocoding.Console.Presentation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddEnvironmentVariables();

builder.Services.Configure<GeocodingApiOptions>(
    builder.Configuration.GetSection(GeocodingApiOptions.SectionName));
builder.Services.AddHttpClient<IGeocodingGateway, GoogleGeocodingGateway>();
builder.Services.AddScoped<LocationLookupService>();
builder.Services.AddScoped<ApplicationRunner>();

using var host = builder.Build();
var runner = host.Services.GetRequiredService<ApplicationRunner>();
await runner.RunAsync();
