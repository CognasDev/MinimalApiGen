using MinimalApiGen.Generators.Abstractions.Command;

namespace MinimalApiGen.Framework.Generation.Command;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public sealed class CommandRoot<TModel> : ICommandRoot<TModel>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    public ICommandWithModelId<TModel> WithNamespace(string commandNamespace) => new CommandWithModelId<TModel>();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public ICommandWithModelId<TModel> WithNamespaceOf<T>() => new CommandWithModelId<TModel>();

    #endregion
}