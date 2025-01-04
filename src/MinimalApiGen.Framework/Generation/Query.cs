using MinimalApiGen.Generators.Abstractions.Get;
using MinimalApiGen.Generators.Abstractions.GetById;
using MinimalApiGen.Generators.Abstractions.Query;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public sealed class Query() : IQuery,
                              IWithGet,
                              IWithGetById,
                              IWithGetWithBusinessLogic,
                              IWithGetWithPagination,
                              IWithGetWithMapping,
                              IQueryWithVersion,
                              IQueryWithServices,
                              IQueryWithKeyedServices,
                              IWithGetWithCache,
                              IQueryWithResponse
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryNamespace"></param>
    /// <returns></returns>
    public IQuery WithNamespace(string queryNamespace) => this;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public IQuery WithNamespaceOf<T>() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithGetWithBusinessLogic WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression) => this;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetWithPagination WithPagination() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetWithMapping WithMappingService() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGet WithGet() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithGetById WithGetById() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IQueryWithResponse WithResponse<TResponse>() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns></returns>
    public IQueryWithVersion WithVersion(int version) => this;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public IWithGetWithCache CachedFor(TimeSpan timeSpan) => this;

    #endregion

    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public IQueryWithServices WithServices<TService1>() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public IQueryWithServices WithServices<TService1, TService2>() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public IQueryWithServices WithServices<TService1, TService2, TService3>() => this;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public IQueryWithServices WithServices<TService1, TService2, TService3, TService4>() => this;

    #endregion

    #region Public Method Declarations - KeyedServices

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <param name="key1"></param>
    /// <returns></returns>
    public IQueryWithKeyedServices WithKeyedServices<TService1>(string key1) => this;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <param name="key1"></param>
    /// <param name="key2"></param>
    /// <returns></returns>
    public IQueryWithKeyedServices WithKeyedServices<TService1, TService2>(string key1, string key2) => this;

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
    public IQueryWithKeyedServices WithKeyedServices<TService1, TService2, TService3>(string key1, string key2, string key3) => this;

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
    public IQueryWithKeyedServices WithKeyedServices<TService1, TService2, TService3, TService4>(string key1, string key2, string key3, string key4) => this;

    #endregion
}