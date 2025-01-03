using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MinimalApiGen.Framework.ExceptionHandling;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : ExceptionHandlerBase<Exception>(logger)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public override int StatusCode => StatusCodes.Status500InternalServerError;

    #endregion
}