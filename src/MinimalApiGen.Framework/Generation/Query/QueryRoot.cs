namespace MinimalApiGen.Framework.Generation.Query1;

/// <summary>
/// 
/// </summary>
public sealed class QueryRoot
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public QueryOperations WithNamespaceOf<T>() => new();

    #endregion
}