using MinimalApiGen.Generators.Abstractions.Command;

namespace MinimalApiGen.Framework.Generation.Command;

/// <summary>
/// 
/// </summary>
public sealed class CommandWithModelId : ICommandWithModelId
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public ICommandOperations WithModelId() => new CommandOperations();

    #endregion
}