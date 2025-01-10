using MinimalApiGen.Generators.Abstractions.Command;

namespace MinimalApiGen.Framework.Generation.Command;

/// <summary>
/// 
/// </summary>
/// <param name="modelType"></param>
public sealed class CommandRoot(Type modelType) : ICommandRoot
{
    #region Field Declarations

    private readonly Type _modelType = modelType;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandNamespace"></param>
    /// <returns></returns>
    public ICommandWithModelId WithNamespace(string commandNamespace) => new CommandWithModelId();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public ICommandWithModelId WithNamespaceOf<T>() => new CommandWithModelId();

    #endregion
}