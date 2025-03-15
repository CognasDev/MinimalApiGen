namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IPostJwtAuthentication
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    IWithPostWithJwtAuthentication WithJwtAuthentication(string role = "");

    #endregion
}