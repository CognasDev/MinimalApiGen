using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MinimalApiGen.Shared.Collections;
using System.Security.Claims;
using System.Text;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public sealed class TokenGenerator : ITokenGenerator
{
    #region Field Declarations

    private readonly IConfiguration _configuration;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="configuration"></param>
    public TokenGenerator(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));
        _configuration = configuration;
    }

    #endregion

    #region Public Method Declarations  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="email"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    public string GenerateToken(string userId, string email, IEnumerable<string> roles)
    {
        JsonWebTokenHandler tokenHandler = new();
        DateTime expiry = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>(JwtConfigNames.Expiration));

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = GetSubject(userId, email, roles),
            Expires = expiry,
            Issuer = _configuration[JwtConfigNames.Issuer],
            Audience = _configuration[JwtConfigNames.Audience],
            SigningCredentials = GetSigningCredentials()
        };

        string token = tokenHandler.CreateToken(tokenDescriptor);
        return token;
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="email"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    private static ClaimsIdentity GetSubject(string userId, string email, IEnumerable<string> roles)
    {
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Sub, userId),
            new(JwtRegisteredClaimNames.Email, email),
            new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
        ];
        roles.FastForEach(role => claims.Add(new(ClaimTypes.Role, role)));
        ClaimsIdentity subject = new(claims);
        return subject;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private SigningCredentials GetSigningCredentials()
    {
        SymmetricSecurityKey symmetricSecurityKey = GetSymmetricSecurityKey();
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        return signingCredentials;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        string secret = _configuration[JwtConfigNames.Secret]!;
        byte[] key = Encoding.UTF8.GetBytes(secret);
        SymmetricSecurityKey symmetricSecurityKey = new(key);
        return symmetricSecurityKey;
    }

    #endregion
}