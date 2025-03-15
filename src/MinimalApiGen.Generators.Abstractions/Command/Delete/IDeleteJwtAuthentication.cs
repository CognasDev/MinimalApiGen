namespace MinimalApiGen.Generators.Abstractions.Command.Delete;

/// <summary>
/// 
/// </summary>
public interface IDeleteJwtAuthentication
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="role"></param>
    /// <returns></returns>
    IWithDeleteWithJwtAuthentication WithJwtAuthentication(string role = "");

    #endregion
}