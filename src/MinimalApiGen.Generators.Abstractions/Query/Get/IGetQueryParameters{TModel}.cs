using System;
using System.Linq.Expressions;

namespace MinimalApiGen.Generators.Abstractions.Query.Get;

/// <summary>
/// 
/// </summary>
public interface IGetQueryParameters
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="properties"></param>
    /// <returns></returns>
    IWithGetWithQueryParameters WithQueryParameters<TModel>(params Expression<Func<TModel, object?>>[] properties);

    #endregion
}