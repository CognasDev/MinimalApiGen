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
    /// <param name="userId"></param>
    /// <param name="email"></param>
    /// <param name="roles"></param>
    /// <returns></returns>
    string GenerateToken(string userId, string email, IEnumerable<string> roles);

    #endregion
}