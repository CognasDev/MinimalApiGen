using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Command.Delete;

/// <summary>
/// 
/// </summary>
public interface IWithDeleteOperation
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithDeleteOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression);

    #endregion
}