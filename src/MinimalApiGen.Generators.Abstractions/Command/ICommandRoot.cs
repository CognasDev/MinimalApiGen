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
    ICommandWithModelId WithNamespaceOf<T>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    ICommandWithModelId WithNamespace(string commandNamespace);

    #endregion
}