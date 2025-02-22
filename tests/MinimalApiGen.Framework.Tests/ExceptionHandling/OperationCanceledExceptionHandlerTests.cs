using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MinimalApiGen.Framework.ExceptionHandling;
using Moq;

namespace MinimalApiGen.Framework.Tests.ExceptionHandling;

/// <summary>
/// 
/// </summary>
public sealed class OperationCanceledExceptionHandlerTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ProblemDetailsTitle()
    {
        ILogger<OperationCanceledExceptionHandler> logger = Mock.Of<ILogger<OperationCanceledExceptionHandler>>();
        OperationCanceledExceptionHandler operationCanceledExceptionHandler = new(logger);
        operationCanceledExceptionHandler.ProblemDetailsTitle.Should().Be(typeof(OperationCanceledException).Name);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void StatusCode()
    {
        ILogger<OperationCanceledExceptionHandler> logger = Mock.Of<ILogger<OperationCanceledExceptionHandler>>();
        OperationCanceledExceptionHandler operationCanceledExceptionHandler = new(logger);
        operationCanceledExceptionHandler.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
    }

    #endregion
}