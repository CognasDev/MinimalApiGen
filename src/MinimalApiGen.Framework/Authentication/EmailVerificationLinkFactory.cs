using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public sealed class EmailVerificationLinkFactory : IEmailVerificationLinkFactory
{
    #region Field Declarations

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LinkGenerator _linkGenerator;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    /// <param name="linkGenerator"></param>
    public EmailVerificationLinkFactory(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
    {
        ArgumentNullException.ThrowIfNull(httpContextAccessor, nameof(httpContextAccessor));
        ArgumentNullException.ThrowIfNull(linkGenerator, nameof(linkGenerator));

        _httpContextAccessor = httpContextAccessor;
        _linkGenerator = linkGenerator;
    }

    #endregion

    #region Public Method Declarations  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="verifyRouteName"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="Exception"></exception>
    public string Create(string userId, string verifyRouteName)
    {
        HttpContext httpContext = _httpContextAccessor.HttpContext ?? throw new NullReferenceException(nameof(HttpContext));
        string? verificationLink = _linkGenerator.GetUriByName(httpContext, verifyRouteName, new { token = userId });

        return verificationLink ?? throw new Exception("Could not create email verification link");
    }

    #endregion
}