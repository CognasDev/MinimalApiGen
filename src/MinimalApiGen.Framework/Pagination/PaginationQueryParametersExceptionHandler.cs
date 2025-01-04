using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.ExceptionHandling;

namespace MinimalApiGen.Framework.Pagination;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
public sealed class PaginationQueryParametersExceptionHandler(ILogger<PaginationQueryParametersExceptionHandler> logger) :
    ExceptionHandlerBase<PaginationQueryParametersException>(logger)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public override int StatusCode => StatusCodes.Status400BadRequest;

    #endregion
}