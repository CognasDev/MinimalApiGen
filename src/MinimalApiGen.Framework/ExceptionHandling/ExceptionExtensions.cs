using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.Pagination;

namespace MinimalApiGen.Framework.ExceptionHandling;

/// <summary>
/// 
/// </summary>
public static class ExceptionExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddExceptionHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddExceptionHandler<PaginationQueryParametersExceptionHandler>();
        serviceCollection.AddExceptionHandler<OperationCanceledExceptionHandler>();
        serviceCollection.AddExceptionHandler<GlobalExceptionHandler>();
    }

    #endregion
}