namespace MinimalApiGen.Framework.Authentication;

/// <summary>
/// 
/// </summary>
public interface IPasswordHasher
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    string Hash(string password);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <param name="passwordHash"></param>
    /// <returns></returns>
    bool Verify(string password, string passwordHash);

    #endregion
}