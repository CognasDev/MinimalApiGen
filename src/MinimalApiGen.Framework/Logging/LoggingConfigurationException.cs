namespace MinimalApiGen.Framework.Logging;

/// <summary>
/// 
/// </summary>
/// <param name="loggingType"></param>
public sealed class LoggingConfigurationException(LoggingType loggingType) : Exception($"Incorrect configuration for {loggingType}.");