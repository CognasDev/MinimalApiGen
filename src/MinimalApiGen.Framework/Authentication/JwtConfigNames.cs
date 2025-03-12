using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
internal static class JwtConfigNames
{
    #region Constant Declarations

    public const string Audience = "Jwt:Audience";
    public const string Expiration = "Jwt:ExpirationInMinutes";
    public const string Issuer = "Jwt:Issuer";  
    public const string Secret = "Jwt:Secret";

    #endregion
}
