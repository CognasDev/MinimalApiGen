using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.Data;
using Moq;

namespace MinimalApiGen.Framework.Tests.Data;

/// <summary>
/// 
/// </summary>
public sealed class SqlExceptionHandlerTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ProblemDetailsTitle()
    {
        ILogger<SqlExceptionHandler> logger = Mock.Of<ILogger<SqlExceptionHandler>>();
        SqlExceptionHandler sqlExceptionHandler = new(logger);
        sqlExceptionHandler.ProblemDetailsTitle.Should().Be(typeof(SqlException).Name);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void StatusCode()
    {
        ILogger<SqlExceptionHandler> logger = Mock.Of<ILogger<SqlExceptionHandler>>();
        SqlExceptionHandler sqlExceptionHandler = new(logger);
        sqlExceptionHandler.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }

    #endregion
}