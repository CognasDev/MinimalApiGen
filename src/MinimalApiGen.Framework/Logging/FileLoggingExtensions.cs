using Serilog;

namespace MinimalApiGen.Framework.Logging;

/// <summary>
/// 
/// </summary>
public static class FileLoggingExtensions
{
    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loggerConfiguration"></param>
    /// <param name="path"></param>
    public static LoggerConfiguration ConfigureFileLogging(this LoggerConfiguration loggerConfiguration, string path)
    {
        return loggerConfiguration.WriteTo
                                  .File(path,
                                        rollingInterval: RollingInterval.Day,
                                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                                  .Enrich.FromLogContext();
    }

    #endregion
}