using MinimalApiGen.Framework.Generation.Query.Common;
using MinimalApiGen.Generators.Abstractions.Query.GetById;
using MinimalApiGen.Generators.Abstractions.Query.Shared;

namespace MinimalApiGen.Framework.Generation.Query.GetById;

/// <summary>
/// 
/// </summary>
public sealed class WithGetByIdWithKeyedServices : IWithGetByIdWithKeyedServices
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
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    public IQueryWithCache CachedFor(TimeSpan timeSpan) => new QueryWithCache();

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
}