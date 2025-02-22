using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiGen.Framework.HealthChecks;

/// <summary>
/// 
/// </summary>
public static class HealthCheckExtensions
{
    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IHealthChecksBuilder AddDefaultHealthChecks(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IHealthCheckService, HealthCheckService>();
        return serviceCollection.AddHealthChecks()
                                .AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck))
                                .AddCheck<DatabaseHealthCheck>(nameof(DatabaseHealthCheck));
    }

    #endregion
}