using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.ExceptionHandling;
using Moq;

namespace MinimalApiGen.Framework.Tests.ExceptionHandling;

/// <summary>
/// 
/// </summary>
public sealed class GlobalExceptionHandlerTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ProblemDetailsTitle()
    {
        ILogger<GlobalExceptionHandler> logger = Mock.Of<ILogger<GlobalExceptionHandler>>();
        GlobalExceptionHandler globalExceptionHandler = new(logger);
        globalExceptionHandler.ProblemDetailsTitle.Should().Be(typeof(Exception).Name);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void StatusCode()
    {
        ILogger<GlobalExceptionHandler> logger = Mock.Of<ILogger<GlobalExceptionHandler>>();
        GlobalExceptionHandler globalExceptionHandler = new(logger);
        globalExceptionHandler.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }

    #endregion
}