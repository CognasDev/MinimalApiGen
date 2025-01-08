namespace MinimalApiGen.Generators.Abstractions.Command;

/// <summary>
/// 
/// </summary>
public interface ICommandRoot
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ICommandOperations WithNamespaceOf<T>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    ICommandOperations WithNamespace(string commandNamespace);

    #endregion
}