using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IWithGetOperation
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithGetOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression);

    #endregion
}