namespace MinimalApiGen.Generators.Abstractions.Command;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface ICommandRoot<TModel>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ICommandWithModelId<TModel> WithNamespaceOf<T>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    ICommandWithModelId<TModel> WithNamespace(string commandNamespace);

    #endregion
}