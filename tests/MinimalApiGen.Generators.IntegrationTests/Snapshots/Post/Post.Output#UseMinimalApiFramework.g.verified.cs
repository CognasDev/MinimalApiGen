//HintName: UseMinimalApiFramework.g.cs
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Generation;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class WebApplicationExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseMinimalApiFramework(this WebApplication webApplication)
    {
        webApplication.UseMinimalApiFrameworkRoutes();
        webApplication.UseOutputCache();
        webApplication.MapHealthChecks("/api/health", new()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        webApplication.UseHttpsRedirection();
        webApplication.UseAuthentication();
		webApplication.UseAuthorization();
    }

    #endregion
}