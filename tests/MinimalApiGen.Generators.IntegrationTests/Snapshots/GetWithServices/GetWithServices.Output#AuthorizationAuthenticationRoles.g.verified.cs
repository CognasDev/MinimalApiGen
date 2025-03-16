//HintName: AuthorizationAuthenticationRoles.g.cs
namespace MinimalApiGen.Framework.Generation;

using MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public static class AuthorizationAuthenticationRoles
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMinimalApiAuthorization(this WebApplicationBuilder builder)
    {
        builder.AddJwtAuthentication();
        builder.Services.AddAuthorization();
    }

    #endregion
}