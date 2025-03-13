using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Command.Post;

/// <summary>
/// 
/// </summary>
public interface IWithPostOperation
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithPostOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression);

    #endregion
}