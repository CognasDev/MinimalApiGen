using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public static class ExtensionMethods
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        IServiceCollection serviceCollection = builder.Services;
        IConfiguration configuration = builder.Configuration;

        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddSingleton<IEmailVerificationLinkFactory, EmailVerificationLinkFactory>();
        serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();
        serviceCollection.AddSingleton<ITokenGenerator, TokenGenerator>();
        serviceCollection.AddAuthorization();
        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = GetKey(configuration),
                    ValidIssuer = configuration[JwtConfigNames.Issuer],
                    ValidAudience = configuration[JwtConfigNames.Audience],
                    ClockSkew = TimeSpan.Zero
                };
            });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseJwtAuthentication(this WebApplication webApplication)
    {
        webApplication.UseAuthentication();
        webApplication.UseAuthorization();
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="configuration"></param>
    /// <exception cref="InvalidOperationException"></exception>
    private static SymmetricSecurityKey GetKey(IConfiguration configuration)
    {
        string? secret = configuration[JwtConfigNames.Secret];
        if (string.IsNullOrWhiteSpace(secret))
        {
            throw new InvalidOperationException($"{JwtConfigNames.Secret} configuration entry is missing.");
        }
        byte[] secretBytes = Encoding.UTF8.GetBytes(secret!);
        SymmetricSecurityKey key = new(secretBytes);
        return key;
    }

    #endregion
}