using System;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class AuthenticationRolesBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="authenticationRoles"></param>
    /// <returns></returns>
    public static string Build(ReadOnlySpan<string> authenticationRoles) =>
$@"namespace MinimalApiGen.Framework.Generation;

using MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public static class AuthorizationAuthenticationRoles
{{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""builder""></param>
    public static void AddMinimalApiAuthorization(this WebApplicationBuilder builder)
    {{
        builder.AddJwtAuthentication();
        builder.Services.AddAuthorization({BuildRoles(authenticationRoles)});
    }}

    #endregion
}}";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="authenticationRoles"></param>
    /// <returns></returns>
    private static string BuildRoles(ReadOnlySpan<string> authenticationRoles)
    {
        if (authenticationRoles.Length == 0)
        {
            return string.Empty;
        }

        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("options =>");
        stringBuilder.AppendLine("\t\t{");

        foreach (string role in authenticationRoles)
        {
            stringBuilder.Append("\t\t\toptions.AddPolicy(\"");
            stringBuilder.Append(role);
            stringBuilder.Append("\", policy => policy.RequireRole(\"");
            stringBuilder.Append(role);
            stringBuilder.AppendLine("\"));");
        }

        stringBuilder.Append("\t\t}");
        string roles = stringBuilder.ToString();
        return roles;
    }

    #endregion
}