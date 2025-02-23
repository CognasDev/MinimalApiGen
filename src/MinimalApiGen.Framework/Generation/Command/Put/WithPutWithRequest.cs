using MinimalApiGen.Framework.Generation.Command.Shared;
using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Put;
using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Framework.Generation.Command.Put;

/// <summary>
/// 
/// </summary>
public sealed class WithPutWithRequest : IWithPutWithRequest
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithPutWithResponse WithResponse<TResponse>() => new WithPutWithResponse();

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

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithPutWithFluentValidation WithFluentValidation() => new WithPutWithFluentValidation();

    #endregion
}