using Microsoft.Extensions.Diagnostics.HealthChecks;
using MinimalApiGen.Framework.Data;
using System.Data;

namespace MinimalApiGen.Framework.HealthChecks;

/// <summary>
/// 
/// </summary>
public sealed class DatabaseHealthCheck : IHealthCheck
{
    #region Field Declarations

    private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
    private readonly IHealthCheckService _healthCheckResultHelper;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="DatabaseHealthCheck"/>
    /// </summary>
    /// <param name="databaseConnectionFactory"></param>
    /// <param name="healthCheckResultHelper"></param>
    public DatabaseHealthCheck(IDatabaseConnectionFactory databaseConnectionFactory, IHealthCheckService healthCheckResultHelper)
    {
        ArgumentNullException.ThrowIfNull(databaseConnectionFactory, nameof(databaseConnectionFactory));
        ArgumentNullException.ThrowIfNull(healthCheckResultHelper, nameof(healthCheckResultHelper));
        _databaseConnectionFactory = databaseConnectionFactory;
        _healthCheckResultHelper = healthCheckResultHelper;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            using IDbConnection dbConnection = _databaseConnectionFactory.Create();

            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
            if (dbConnection.State == System.Data.ConnectionState.Open)
            {
                dbConnection.Close();
                HealthCheckResult healthyResult = _healthCheckResultHelper.Healthy("Successful database connection.");
                return await Task.FromResult(healthyResult);
            }

            HealthCheckResult cannontConnectResult = BuildCannotConnectResult(context.Registration.FailureStatus);
            return await Task.FromResult(cannontConnectResult);
        }
        catch (Exception exception)
        {
            HealthCheckResult cannontConnectResult = BuildCannotConnectResult(context.Registration.FailureStatus, exception);
            return await Task.FromResult(cannontConnectResult);
        }
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="failureStatus"></param>
    /// <param name="exception"></param>
    /// <returns></returns>
    private HealthCheckResult BuildCannotConnectResult(HealthStatus failureStatus, Exception? exception = null) =>
        _healthCheckResultHelper.Failed(failureStatus, "Unsuccessful database connection.", exception);

    #endregion
}