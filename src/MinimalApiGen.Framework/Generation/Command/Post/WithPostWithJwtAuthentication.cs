using MinimalApiGen.Generators.Abstractions.Command.Post;

namespace MinimalApiGen.Framework.Generation.Command.Post;

/// <summary>
/// 
/// </summary>
public sealed class WithPostWithJwtAuthentication : IWithPostWithJwtAuthentication
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns></returns>
    public IWithPostWithRequest WithRequest<TRequest>() => new WithPostWithRequest();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithPostWithResponse WithResponse<TResponse>() => new WithPostWithResponse();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEndpointFilter"></typeparam>
    /// <returns></returns>
    public IWithPostWithAddEndpointFilter WithAddEndpointFilter<TEndpointFilter>() => new WithPostWithAddEndpointFilter();

    #endregion

    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public IWithPostWithServices WithServices<TService1>() => new WithPostWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public IWithPostWithServices WithServices<TService1, TService2>() => new WithPostWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public IWithPostWithServices WithServices<TService1, TService2, TService3>() => new WithPostWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public IWithPostWithServices WithServices<TService1, TService2, TService3, TService4>() => new WithPostWithServices();

    #endregion

    #region Public Method Declarations - KeyedServices

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <param name="key1"></param>
    /// <returns></returns>
    public IWithPostWithKeyedServices WithKeyedServices<TService1>(string key1) => new WithPostWithKeyedServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    public IWithPostWithKeyedServices WithKeyedServices<TService1, TService2>(string key1, string key2) => new WithPostWithKeyedServices();

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
    public IWithPostWithKeyedServices WithKeyedServices<TService1, TService2, TService3>(string key1, string key2, string key3) => new WithPostWithKeyedServices();

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
    public IWithPostWithKeyedServices WithKeyedServices<TService1, TService2, TService3, TService4>(string key1, string key2, string key3, string key4) => new WithPostWithKeyedServices();

    #endregion
}