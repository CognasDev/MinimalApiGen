using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Framework.Generation.Command.Common;

/// <summary>
/// 
/// </summary>
public sealed class CommandWithResponseMappingService : ICommandWithResponseMappingService
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public ICommandOperations WithVersion(int version) => new CommandOperations();

    #endregion
}