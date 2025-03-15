//HintName: UseMinimalApiFramework.g.cs
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Swagger;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class UseMinimalApiFrameworkExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseMinimalApiFramework(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.AddSwagger();
        }

        webApplication.UseMinimalApiFrameworkRoutes();
        webApplication.UseOutputCache();
        webApplication.MapHealthChecks("/api/health", new()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        webApplication.UseHttpsRedirection();
        
    }

    #endregion
}