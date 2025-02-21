using MinimalApiGen.Generators.Abstractions.Command.Put;

namespace MinimalApiGen.Framework.Generation.Command.Put;

/// <summary>
/// 
/// </summary>
public sealed class WithPutWithKeyedServices : IWithPutWithKeyedServices
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithPutWithResponse WithResponse<TResponse>() => new WithPutWithResponse();

    #endregion

    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public IWithPutWithServices WithServices<TService1>() => new WithPutWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public IWithPutWithServices WithServices<TService1, TService2>() => new WithPutWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public IWithPutWithServices WithServices<TService1, TService2, TService3>() => new WithPutWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public IWithPutWithServices WithServices<TService1, TService2, TService3, TService4>() => new WithPutWithServices();

    #endregion
}