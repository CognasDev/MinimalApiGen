using MinimalApiGen.Framework.Generation.Command.Shared;
using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Post;
using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Framework.Generation.Command.Post;

/// <summary>
/// 
/// </summary>
public sealed class WithPostWithRequest : IWithPostWithRequest
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
    /// <returns></returns>
    public ICommandWithRequestMappingService WithRequestMappingService() => new CommandWithRequestMappingService();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ICommandWithResponseMappingService WithResponseMappingService() => new CommandWithResponseMappingService();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public ICommandOperations WithVersion(int version) => new CommandOperations();

    #endregion
}