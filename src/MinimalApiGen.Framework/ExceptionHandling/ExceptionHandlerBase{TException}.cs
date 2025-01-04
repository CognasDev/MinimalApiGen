using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MinimalApiGen.Framework.ExceptionHandling;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TException"></typeparam>
public abstract class ExceptionHandlerBase<TException> : IExceptionHandler where TException : Exception
{
    #region Field Declarations

    private readonly ILogger _logger;

    #endregion

    #region Property Declarations

    /// <summary>
    /// This property should return a constant defined in <see cref="Microsoft.AspNetCore.Http.StatusCodes"/>.
    /// </summary>
    public abstract int StatusCode { get; }

    /// <summary>
    /// 
    /// </summary>
    public virtual string ProblemDetailsTitle { get; } = typeof(TException).Name;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// Default constructor for <see cref="ExceptionHandlerBase{TException}"/>
    /// </summary>
    /// <param name="logger"></param>
    protected ExceptionHandlerBase(ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        _logger = logger;
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContext"></param>
    /// <param name="exception"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not TException stronglyTypedException)
        {
            return false;
        }

        _logger.LogError(stronglyTypedException, "Exception occurred: {LoggingMessage}", LoggingMessage(stronglyTypedException));

        httpContext.Response.StatusCode = StatusCode;
        ProblemDetails problemDetails = CreateProblemDetails(stronglyTypedException);
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stronglyTypedException"></param>
    /// <returns></returns>
    public virtual string LoggingMessage(TException stronglyTypedException) => stronglyTypedException.Message;

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stronglyTypedException"></param>
    /// <returns></returns>
    private ProblemDetails CreateProblemDetails(TException stronglyTypedException)
    {
        ProblemDetails problemDetails = new()
        {
            Status = StatusCode,
            Title = ProblemDetailsTitle,
            Detail = stronglyTypedException.Message
        };
        return problemDetails;
    }

    #endregion
}