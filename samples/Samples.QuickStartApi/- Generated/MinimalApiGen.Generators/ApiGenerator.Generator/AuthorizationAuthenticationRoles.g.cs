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
			options.AddPolicy("ExampleRole", policy => policy.RequireRole("ExampleRole"));
			options.AddPolicy("Test", policy => policy.RequireRole("Test"));
		});
    }

    #endregion
}