using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Query;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TModel"></typeparam>
public interface IQueryWithModelId<TModel>
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    IQueryOperations WithModelId(Expression<Func<TModel, object?>> property);

    #endregion
}