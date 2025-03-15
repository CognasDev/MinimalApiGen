using MinimalApiGen.Generators.Abstractions.Query.Get;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Query.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithJwtAuthentication : IWithGetWithJwtAuthentication
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="properties"></param>
    /// <returns></returns>
    public IWithGetWithQueryParameters WithQueryParameters<TModel>(params Expression<Func<TModel, object?>>[] properties) => new WithGetWithQueryParameters();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithGetWithResponse WithResponse<TResponse>() => new WithGetWithResponse();

    #endregion

    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public IWithGetWithServices WithServices<TService1>() => new WithGetWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public IWithGetWithServices WithServices<TService1, TService2>() => new WithGetWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public IWithGetWithServices WithServices<TService1, TService2, TService3>() => new WithGetWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public IWithGetWithServices WithServices<TService1, TService2, TService3, TService4>() => new WithGetWithServices();

    #endregion

    #region Public Method Declarations - KeyedServices

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <param name="key1"></param>
    /// <returns></returns>
    public IWithGetWithKeyedServices WithKeyedServices<TService1>(string key1) => new WithGetWithKeyedServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    public IWithGetWithKeyedServices WithKeyedServices<TService1, TService2>(string key1, string key2) => new WithGetWithKeyedServices();

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
    public IWithGetWithKeyedServices WithKeyedServices<TService1, TService2, TService3>(string key1, string key2, string key3) => new WithGetWithKeyedServices();

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
    public IWithGetWithKeyedServices WithKeyedServices<TService1, TService2, TService3, TService4>(string key1, string key2, string key3, string key4) => new WithGetWithKeyedServices();

    #endregion
}