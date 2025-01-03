using Microsoft.AspNetCore.Http;
using MinimalApiGen.Framework.Extensions;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace MinimalApiGen.Framework.Pagination;

/// <summary>
/// 
/// </summary>
public sealed class PaginationService : IPaginationService
{
    #region Field Declarations

    private readonly ConcurrentDictionary<string, PropertyDescriptor?> _orderByCache = new();

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    public int TakeQuantity(IPaginationQuery paginationQuery) => paginationQuery.PageSize!.Value;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    public int SkipNumber(IPaginationQuery paginationQuery) => (paginationQuery.PageNumber!.Value - 1) * TakeQuantity(paginationQuery);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResonse"></typeparam>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    /// <exception cref="PaginationQueryParametersException"></exception>
    public PropertyDescriptor OrderByProperty<TResonse>(IPaginationQuery paginationQuery) where TResonse : class
    {
        string cacheKey = $"{typeof(TResonse).Name}.{paginationQuery.OrderBy}";
        PropertyDescriptor? orderByProperty = _orderByCache.GetOrAdd(cacheKey, key => TypeDescriptor.GetProperties(typeof(TResonse)).Find(paginationQuery.OrderBy!, true))
                                              ?? throw new PaginationQueryParametersException(paginationQuery.OrderBy!, typeof(TResonse));
        return orderByProperty!;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResonse"></typeparam>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    public bool? IsPaginationQueryValidOrNotRequested<TResonse>(IPaginationQuery paginationQuery) where TResonse : class
    {
        if (IsEmpty(paginationQuery))
        {
            return null;
        }
        bool isValid = paginationQuery.PageNumber.HasValue &&
                       paginationQuery.PageSize.HasValue &&
                       !string.IsNullOrWhiteSpace(paginationQuery.OrderBy) &&
                       OrderByProperty<TResonse>(paginationQuery) is not null;
        return isValid;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="paginationQuery"></param>
    /// <param name="models"></param>
    /// <param name="httpContext"></param>
    public void BuildPaginationResponseHeader<TModel>(IPaginationQuery paginationQuery, IEnumerable<TModel> models, HttpContext httpContext) where TModel : class
    {
        int modelCount = models.TryGetNonEnumeratedCount(out int count) ? count : models.Count();
        int pageCount = ((modelCount - 1) / paginationQuery.PageSize!.Value) + 1;
        IHeaderDictionary headers = httpContext.Response.Headers;

        headers.AppendSanitised("x-total", modelCount);
        headers.AppendSanitised("x-page-count", pageCount);
        headers.AppendSanitised("x-page-size", paginationQuery.PageSize!.Value);
        headers.AppendSanitised("x-page-number", paginationQuery.PageNumber!.Value);
        headers.AppendSanitised($"x-page-{nameof(paginationQuery.OrderBy).ToLower()}", paginationQuery.OrderBy!);
        headers.AppendSanitised($"x-page-{nameof(paginationQuery.OrderByAscending).ToLower()}", paginationQuery.OrderByAscending ?? true);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="paginationQuery"></param>
    /// <returns></returns>
    private static bool IsEmpty(IPaginationQuery paginationQuery)
    {
        return paginationQuery.PageSize == null &&
               paginationQuery.PageNumber == null &&
               string.IsNullOrWhiteSpace(paginationQuery.OrderBy) &&
               paginationQuery.OrderByAscending == null;
    }

    #endregion
}