using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Query.GetById;

/// <summary>
/// 
/// </summary>
public interface IWithGetByIdOperation
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithGetByIdOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression);

    #endregion
}