namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class UseMinimalApiFrameworkBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="withJwtAuthentication"></param>
    /// <returns></returns>
    public static string Build(bool withJwtAuthentication) =>
@$"using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Generation;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class WebApplicationExtensions
{{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""webApplication""></param>
    public static void UseMinimalApiFramework(this WebApplication webApplication)
    {{
        webApplication.UseMinimalApiFrameworkRoutes();
        webApplication.UseOutputCache();
        webApplication.MapHealthChecks(""/api/health"", new()
        {{
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        }});
        webApplication.UseHttpsRedirection();
        {AddAuthentication(withJwtAuthentication)}
    }}

    #endregion
}}";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="withJwtAuthentication"></param>
    /// <returns></returns>
    private static string AddAuthentication(bool withJwtAuthentication)
    {
        if (!withJwtAuthentication)
        {
            return string.Empty;
        }
        string authentication = $"webApplication.UseAuthentication();\r\n\t\twebApplication.UseAuthorization();";
        return authentication;
    }

    #endregion
}