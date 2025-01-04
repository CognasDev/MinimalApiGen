using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace MinimalApiGen.Framework.Pagination;

/// <summary>
/// 
/// </summary>
public interface IPaginationService
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    int TakeQuantity(IPaginationQuery paginationQuery);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    int SkipNumber(IPaginationQuery paginationQuery);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResonse"></typeparam>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    /// <exception cref="PaginationQueryParametersException"></exception>
    PropertyDescriptor OrderByProperty<TResonse>(IPaginationQuery paginationQuery) where TResonse : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResonse"></typeparam>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    bool? IsPaginationQueryValidOrNotRequested<TResonse>(IPaginationQuery paginationQuery) where TResonse : class;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResonse"></typeparam>
    /// <param name="paginationQuery"></param>
    /// <param name="responses"></param>
    /// <param name="httpContext"></param>
    void BuildPaginationResponseHeader<TResonse>(IPaginationQuery paginationQuery, IEnumerable<TResonse> responses, HttpContext httpContext) where TResonse : class;

    #endregion
}