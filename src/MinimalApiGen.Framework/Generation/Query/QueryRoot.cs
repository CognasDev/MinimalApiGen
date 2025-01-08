using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Framework.Generation.Query;

/// <summary>
/// 
/// </summary>
public sealed class QueryRoot : IQueryRoot
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public IQueryOperations WithNamespaceOf<T>() => new QueryOperations();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryNamespace"></param>
    /// <returns></returns>
    public IQueryOperations WithNamespace(string queryNamespace) => new QueryOperations();

    #endregion
}