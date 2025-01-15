using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Framework.Generation.Query;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public sealed class QueryRoot<TModel> : IQueryRoot<TModel>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    public IQueryWithModelId<TModel> WithNamespace(string commandNamespace) => new QueryWithModelId<TModel>();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public IQueryWithModelId<TModel> WithNamespaceOf<T>() => new QueryWithModelId<TModel>();

    #endregion
}