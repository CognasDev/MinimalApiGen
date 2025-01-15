namespace MinimalApiGen.Generators.Abstractions.Query;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface IQueryRoot<TModel>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    IQueryWithModelId<TModel> WithNamespaceOf<T>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    IQueryWithModelId<TModel> WithNamespace(string commandNamespace);

    #endregion
}