using MinimalApiGen.Framework.Generation.Command.Post;
using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Post;
using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Framework.Generation.Command.Shared;

/// <summary>
/// 
/// </summary>
public sealed class CommandWithRequestMappingService : ICommandWithRequestMappingService
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithPostWithResponse WithResponse<TResponse>() => new WithPostWithResponse();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public ICommandOperations WithVersion(int version) => new CommandOperations();

    #endregion
}