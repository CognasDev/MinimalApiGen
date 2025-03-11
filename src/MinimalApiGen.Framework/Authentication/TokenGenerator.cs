using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public sealed class TokenGenerator : ITokenGenerator
{
    #region Public Method Declarations  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="domain"></param>
    /// <param name="expiresMinutes"></param>
    /// <returns></returns>
    public string GenerateToken(string email, string domain, int expiresMinutes = 60)
    {
        string issuer = $"https://id.{domain}";
        string audience = $"https://{domain}";
        return GenerateToken(email, issuer, audience, expiresMinutes);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="issuer"></param>
    /// <param name="audience"></param>
    /// <param name="expiresMinutes"></param>
    /// <returns></returns>
    public string GenerateToken(string email, string issuer, string audience, int expiresMinutes = 60)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        DateTime expiry = DateTime.UtcNow.AddMinutes(expiresMinutes);

        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = GetSubject(email),
            Expires = expiry,
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = GetSigningCredentials()
        };

        SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
        string token = tokenHandler.WriteToken(securityToken);
        return token;
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// <param name="email"></param>
    /// <returns></returns>
    /// </summary>
    private static ClaimsIdentity GetSubject(string email)
    {
        string jti = Guid.NewGuid().ToString();
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Jti, jti),
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.Email, email)
        ];
        ClaimsIdentity subject = new(claims);
        return subject;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static SigningCredentials GetSigningCredentials()
    {
        byte[] key = "ForTheLoveOfGodStoreAndLoadThisSecurely"u8.ToArray();
        SymmetricSecurityKey symmetricSecurityKey = new(key);
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        return signingCredentials;
    }

    #endregion
}