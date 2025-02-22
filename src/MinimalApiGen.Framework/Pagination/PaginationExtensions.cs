using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.Pagination;

namespace MinimalApiGen.Framework.HealthChecks;

/// <summary>
/// 
/// </summary>
public static class PaginationExtensions
{
    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static void AddPagination(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IPaginationService, PaginationService>();
        serviceCollection.AddExceptionHandler<PaginationQueryParametersExceptionHandler>();
    }

    #endregion
}