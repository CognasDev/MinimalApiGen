namespace MinimalApiGen.Generators.Abstractions.Query;

/// <summary>
/// 
/// </summary>
public interface IQueryRoot
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    IQueryOperations WithNamespaceOf<T>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryNamespace"></param>
    /// <returns></returns>
    IQueryOperations WithNamespace(string queryNamespace);

    #endregion
}