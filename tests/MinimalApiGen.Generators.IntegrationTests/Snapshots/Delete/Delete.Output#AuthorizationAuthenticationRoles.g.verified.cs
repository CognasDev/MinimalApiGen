//HintName: AuthorizationAuthenticationRoles.g.cs
namespace MinimalApiGen.Framework.Generation;

using Microsoft.AspNetCore.Builder;
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
        builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("SampleRole", policy => policy.RequireRole("SampleRole"));
		});
    }

    #endregion
}