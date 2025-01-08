using MinimalApiGen.Generators.Abstractions.Command;

namespace MinimalApiGen.Framework.Generation.Command;

/// <summary>
/// 
/// </summary>
public sealed class CommandRoot : ICommandRoot
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    public ICommandOperations WithNamespace(string commandNamespace) => new CommandOperations();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public ICommandOperations WithNamespaceOf<T>() => new CommandOperations();

    #endregion

}