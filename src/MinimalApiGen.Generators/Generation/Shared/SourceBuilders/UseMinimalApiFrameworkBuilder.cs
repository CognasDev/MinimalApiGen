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
    /// <param name="withCaching"></param>
    /// <returns></returns>
    public static string Build(bool withJwtAuthentication, bool withCaching) =>
@$"using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Swagger;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class UseMinimalApiFrameworkExtensions
{{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""webApplication""></param>
    public static void UseMinimalApiFramework(this WebApplication webApplication)
    {{
        if (webApplication.Environment.IsDevelopment())
        {{
            webApplication.AddSwagger();
        }}

        webApplication.UseMinimalApiFrameworkRoutes();
        {UseCaching(withCaching)}
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
    private static string AddAuthentication(bool withJwtAuthentication) => withJwtAuthentication ? $"webApplication.UseAuthentication();\r\n\t\twebApplication.UseAuthorization();" : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="withCaching"></param>
    /// <returns></returns>
    private static string UseCaching(bool withCaching) => withCaching ? "webApplication.UseOutputCache();" : string.Empty;

    #endregion
}