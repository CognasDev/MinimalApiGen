namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public interface ITokenGenerator
{
    #region Method Declarations  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="domain"></param>
    /// <param name="expiresMinutes"></param>
    /// <returns></returns>
    string GenerateToken(string email, string domain, int expiresMinutes = 60);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="issuer"></param>
    /// <param name="audience"></param>
    /// <param name="expiresMinutes"></param>
    /// <returns></returns>
    string GenerateToken(string email, string issuer, string audience, int expiresMinutes = 60);

    #endregion
}