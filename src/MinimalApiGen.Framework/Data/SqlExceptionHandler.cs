using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.ExceptionHandling;

namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
public sealed class SqlExceptionHandler(ILogger<SqlExceptionHandler> logger) : ExceptionHandlerBase<SqlException>(logger)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public override int StatusCode => StatusCodes.Status500InternalServerError;

    #endregion
}