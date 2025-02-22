using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.Pagination;
using Moq;

namespace MinimalApiGen.Framework.Tests.Pagination;

/// <summary>
/// 
/// </summary>
public sealed class PaginationQueryParametersExceptionHandlerTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ProblemDetailsTitle()
    {
        ILogger<PaginationQueryParametersExceptionHandler> logger = Mock.Of<ILogger<PaginationQueryParametersExceptionHandler>>();
        PaginationQueryParametersExceptionHandler sqlExceptionHandler = new(logger);
        sqlExceptionHandler.ProblemDetailsTitle.Should().Be(typeof(PaginationQueryParametersException).Name);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void StatusCode()
    {
        ILogger<PaginationQueryParametersExceptionHandler> logger = Mock.Of<ILogger<PaginationQueryParametersExceptionHandler>>();
        PaginationQueryParametersExceptionHandler sqlExceptionHandler = new(logger);
        sqlExceptionHandler.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
    }

    #endregion
}