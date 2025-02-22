using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MinimalApiGen.Framework.HealthChecks;

/// <summary>
/// 
/// </summary>
public sealed class HealthCheckService : IHealthCheckService
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public HealthCheckResult Healthy(string description) => HealthCheckResult.Healthy(description);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="failureStatus"></param>
    /// <param name="description"></param>
    /// <param name="exception"></param>
    /// <returns></returns>
    public HealthCheckResult Failed(HealthStatus failureStatus, string description, Exception? exception = null)
    {
        HealthCheckResult healthCheckResult;
        if (exception is not null)
        {
            ProblemDetails problemDetails = new()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = exception.GetType().Name,
                Detail = exception.Message
            };
            Dictionary<string, object> data = new(1) { { nameof(ProblemDetails), problemDetails } };
            healthCheckResult = new(failureStatus, description, data: data);
        }
        else
        {
            healthCheckResult = new(failureStatus, description);
        }
        return healthCheckResult;
    }

    #endregion
}