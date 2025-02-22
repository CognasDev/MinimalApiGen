using Serilog;

namespace MinimalApiGen.Framework.Logging;

/// <summary>
/// 
/// </summary>
public static class OpenTelemetryExtensions
{
    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loggerConfiguration"></param>
    /// <param name="endpoint"></param>
    /// <param name="apiKeyHeader"></param>
    /// <param name="apiKeyValue"></param>
    /// <param name="serviceName"></param>
    public static LoggerConfiguration ConfigureOpenTelemetryLogging(this LoggerConfiguration loggerConfiguration, string endpoint, string apiKeyHeader, string apiKeyValue, string serviceName)
    {
        return loggerConfiguration.WriteTo.OpenTelemetry(sinkOptions =>
        {
            sinkOptions.Endpoint = endpoint;
            sinkOptions.Protocol = Serilog.Sinks.OpenTelemetry.OtlpProtocol.HttpProtobuf;
            sinkOptions.Headers = new Dictionary<string, string>(1) { [apiKeyHeader] = apiKeyValue };
            sinkOptions.ResourceAttributes = new Dictionary<string, object>(1) { ["service.name"] = serviceName };
        });
    }

    #endregion
}