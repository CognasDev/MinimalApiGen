using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MinimalApiGen.Framework.Logging;

/// <summary>
/// 
/// </summary>
public static class ApplicationInsightsExtensions
{
    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplicationBuilder"></param>
    /// <exception cref="NullReferenceException"></exception>
    public static IHostBuilder ConfigureApplicationInsightsLogging(this WebApplicationBuilder webApplicationBuilder)
    {
        string connectionString = webApplicationBuilder.Configuration.GetValue<string>("ApplicationInsights:ConnectionString") ?? throw new NullReferenceException("ApplicationInsights");
        TelemetryConfiguration telemetryConfiguration = new() { ConnectionString = connectionString };
        webApplicationBuilder.Logging.AddAzureWebAppDiagnostics();
        return webApplicationBuilder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) => loggerConfiguration.ReadFrom
                                                                                                                     .Configuration(hostBuilderContext.Configuration)
                                                                                                                     .WriteTo
                                                                                                                     .ApplicationInsights(telemetryConfiguration, TelemetryConverter.Traces));
    }

    #endregion
}