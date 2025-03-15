namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
public static class JwtAuthenticationBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static string Build() =>
$@"
        .RequireAuthorization()";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public static string BuildRole(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
        {
            return string.Empty;
        }
        return
$@"
            [Authorize(Policy = ""{role}"")]";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    public static string BuildUsings(string role)
    {
        if (string.IsNullOrWhiteSpace(role))
        {
            return string.Empty;
        }
        return
$@"
using Microsoft.AspNetCore.Authorization;
";
    }

    #endregion
}