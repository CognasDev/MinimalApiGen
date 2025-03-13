using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Command.Put;

/// <summary>
/// 
/// </summary>
public interface IWithPutOperation
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithPutOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression);

    #endregion
}