using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.ExceptionHandling;
using Moq;

namespace MinimalApiGen.Framework.Tests.ExceptionHandling;

/// <summary>
/// 
/// </summary>
public sealed class ExceptionHandlerBaseTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public async Task CorrectExceptionType_TryHandleAsync()
    {
        ILogger<TestExceptionHandler> logger = Mock.Of<ILogger<TestExceptionHandler>>();
        HttpContext httpContext = new DefaultHttpContext();
        Mock<TestExceptionHandler> mockExceptionHandlerBase = new(logger)
        {
            CallBase = true
        };

        ExceptionHandlerBase<Exception> exceptionHandlerBase = mockExceptionHandlerBase.Object;
        bool result = await exceptionHandlerBase.TryHandleAsync(httpContext, new Exception(), It.IsAny<CancellationToken>());
        mockExceptionHandlerBase.Object.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeTrue();
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public async Task IncorrectExceptionType_TryHandleAsync()
    {
        ILogger<TestExceptionHandler> logger = Mock.Of<ILogger<TestExceptionHandler>>();
        HttpContext httpContext = new DefaultHttpContext();
        Mock<TestExceptionHandler> mockExceptionHandlerBase = new(logger)
        {
            CallBase = true
        };

        ExceptionHandlerBase<Exception> exceptionHandlerBase = mockExceptionHandlerBase.Object;
        bool result = await exceptionHandlerBase.TryHandleAsync(httpContext, It.IsAny<Exception>(), It.IsAny<CancellationToken>());
        result.Should().BeFalse();
    }

    #endregion

    #region Fixtures

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public class TestExceptionHandler(ILogger<ExceptionHandlerBaseTests.TestExceptionHandler> logger) : ExceptionHandlerBase<Exception>(logger)
    {
        #region Property Declarations

        /// <summary>
        /// 
        /// </summary>
        public override int StatusCode => StatusCodes.Status200OK;

        #endregion
    }

    #endregion
}