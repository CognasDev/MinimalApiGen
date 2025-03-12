namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public interface IEmailVerificationLinkFactory
{
    #region Method Declarations  

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="verifyRouteName"></param>
    /// <returns></returns>
    string Create(string userId, string verifyRouteName);

    #endregion
}