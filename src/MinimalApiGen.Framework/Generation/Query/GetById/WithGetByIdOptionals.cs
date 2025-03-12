using MinimalApiGen.Generators.Abstractions.Query.GetById;

namespace MinimalApiGen.Framework.Generation.Query.GetById;

/// <summary>
/// 
/// </summary>
public sealed class WithGetByIdOptionals : IWithGetByIdOptionals
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithGetByIdWithResponse WithResponse<TResponse>() => new WithGetByIdWithResponse();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetByIdWithJwtAuthentication WithJwtAuthentication() => new WithGetByIdWithJwtAuthentication();

    #endregion

    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public IWithGetByIdWithServices WithServices<TService1>() => new WithGetByIdWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public IWithGetByIdWithServices WithServices<TService1, TService2>() => new WithGetByIdWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public IWithGetByIdWithServices WithServices<TService1, TService2, TService3>() => new WithGetByIdWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public IWithGetByIdWithServices WithServices<TService1, TService2, TService3, TService4>() => new WithGetByIdWithServices();

    #endregion

    #region Public Method Declarations - KeyedServices

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <param name="key1"></param>
    /// <returns></returns>
    public IWithGetByIdWithKeyedServices WithKeyedServices<TService1>(string key1) => new WithGetByIdWithKeyedServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    public IWithGetByIdWithKeyedServices WithKeyedServices<TService1, TService2>(string key1, string key2) => new WithGetByIdWithKeyedServices();

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
    public IWithGetByIdWithKeyedServices WithKeyedServices<TService1, TService2, TService3>(string key1, string key2, string key3) => new WithGetByIdWithKeyedServices();

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
    public IWithGetByIdWithKeyedServices WithKeyedServices<TService1, TService2, TService3, TService4>(string key1, string key2, string key3, string key4) => new WithGetByIdWithKeyedServices();

    #endregion
}