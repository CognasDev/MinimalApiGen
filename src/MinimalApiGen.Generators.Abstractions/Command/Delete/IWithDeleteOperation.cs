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
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithDeleteOptionals WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression);

    #endregion
}