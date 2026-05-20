using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using SharpCortex.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddOpenApi();

builder.Services
    .AddOpenTelemetry()
    .WithTracing(tracing =>
    {
        tracing
            .SetResourceBuilder(
                ResourceBuilder.CreateDefault()
                    .AddService("SharpCortex.Api"))
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddConsoleExporter();
    });

var postgresConnection =
    builder.Configuration.GetConnectionString("Postgres");

var healthChecks = builder.Services.AddHealthChecks();

if (!string.IsNullOrWhiteSpace(postgresConnection))
{
    healthChecks.AddNpgSql(postgresConnection);
}

builder.Services.Configure<OllamaOptions>(builder.Configuration.GetSection(OllamaOptions.SectionName));
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.MapOpenApi();

app.MapHealthChecks("/health");

app.MapGet("/", () => Results.Ok(new
{
    Name = "SharpCortex.Api",
    Status = "Running"
}));

app.Run();