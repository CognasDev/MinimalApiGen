using MinimalApiGen.Generators.Abstractions.Command.Put;

namespace MinimalApiGen.Framework.Generation.Command.Put;

/// <summary>
/// 
/// </summary>
public sealed class WithPutWithJwtAuthentication : IWithPutWithJwtAuthentication
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns></returns>
    public IWithPutWithRequest WithRequest<TRequest>() => new WithPutWithRequest();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithPutWithResponse WithResponse<TResponse>() => new WithPutWithResponse();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEndpointFilter"></typeparam>
    /// <returns></returns>
    public IWithPutWithAddEndpointFilter WithAddEndpointFilter<TEndpointFilter>() => new WithPutWithAddEndpointFilter();

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

    #region Public Method Declarations - KeyedServices

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <param name="key1"></param>
    /// <returns></returns>
    public IWithPutWithKeyedServices WithKeyedServices<TService1>(string key1) => new WithPutWithKeyedServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    public IWithPutWithKeyedServices WithKeyedServices<TService1, TService2>(string key1, string key2) => new WithPutWithKeyedServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <param name="key3"></param>
    /// <returns></returns>
    public IWithPutWithKeyedServices WithKeyedServices<TService1, TService2, TService3>(string key1, string key2, string key3) => new WithPutWithKeyedServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <param name="key3"></param>
    /// <param name="key4"></param>
    /// <returns></returns>
    public IWithPutWithKeyedServices WithKeyedServices<TService1, TService2, TService3, TService4>(string key1, string key2, string key3, string key4) => new WithPutWithKeyedServices();

    #endregion
}