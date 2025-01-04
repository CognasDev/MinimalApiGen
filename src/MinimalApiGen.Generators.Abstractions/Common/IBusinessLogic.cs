using MinimalApiGen.Generators.Abstractions.Get;
using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Common;

/// <summary>
/// 
/// </summary>
public interface IBusinessLogic
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    IWithGetWithBusinessLogic WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression);

    #endregion
}