using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MinimalApiGen.Framework.HealthChecks;

/// <summary>
/// 
/// </summary>
public interface IHealthCheckService
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    HealthCheckResult Healthy(string description);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="failureStatus"></param>
    /// <param name="description"></param>
    /// <param name="exception"></param>
    /// <returns></returns>
    HealthCheckResult Failed(HealthStatus failureStatus, string description, Exception? exception = null);

    #endregion
}