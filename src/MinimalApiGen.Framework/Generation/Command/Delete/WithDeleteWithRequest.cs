using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Delete;

namespace MinimalApiGen.Framework.Generation.Command.Delete;

/// <summary>
/// 
/// </summary>
public sealed class WithDeleteWithRequest : IWithDeleteWithRequest
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithDeleteWithJwtAuthentication WithJwtAuthentication(string role = "") => new WithDeleteWithJwtAuthentication();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public ICommandOperations WithVersion(int version) => new CommandOperations();

    #endregion
}