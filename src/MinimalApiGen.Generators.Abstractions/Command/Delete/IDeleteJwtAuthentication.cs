using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Generators.Abstractions.Command.Delete;

/// <summary>
/// 
/// </summary>
public interface IDeleteJwtAuthentication : IVersion
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