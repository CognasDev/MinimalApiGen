using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Command;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface ICommandWithModelId<TModel>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    ICommandOperations WithModelId(Expression<Func<TModel, object?>> property);

    #endregion
}