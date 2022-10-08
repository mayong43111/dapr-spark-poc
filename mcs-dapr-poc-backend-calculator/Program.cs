using MCS.Dapr.POC.Backend.Calculator.Meters;
using OpenTelemetry.Metrics;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddOpenTelemetryMetrics(builder =>
        {
            builder.AddMeter(MeterHelper.MeterName);
            builder.AddPrometheusExporter();
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseOpenTelemetryPrometheusScrapingEndpoint();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}