using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MinimalApiGen.Framework.ExceptionHandling;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
public sealed class OperationCanceledExceptionHandler(ILogger<OperationCanceledExceptionHandler> logger) : ExceptionHandlerBase<OperationCanceledException>(logger)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public override int StatusCode => StatusCodes.Status500InternalServerError;

    #endregion
}