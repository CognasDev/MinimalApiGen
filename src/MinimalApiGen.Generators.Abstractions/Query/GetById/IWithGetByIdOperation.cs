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
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithGetByIdOptionals WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression);

    #endregion
}