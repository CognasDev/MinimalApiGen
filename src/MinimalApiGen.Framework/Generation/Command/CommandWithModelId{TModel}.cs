using MinimalApiGen.Generators.Abstractions.Command;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Command;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public sealed class CommandWithModelId<TModel> : ICommandWithModelId<TModel>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public ICommandOperations WithModelId(Expression<Func<TModel, object?>> property) => new CommandOperations();

    #endregion
}