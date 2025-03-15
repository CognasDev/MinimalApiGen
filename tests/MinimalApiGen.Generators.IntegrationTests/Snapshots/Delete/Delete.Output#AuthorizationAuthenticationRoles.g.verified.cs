//HintName: AuthorizationAuthenticationRoles.g.cs
namespace MinimalApiGen.Framework.Generation;

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
        builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("SampleRole", policy => policy.RequireRole("SampleRole"));
		});
    }

    #endregion
}