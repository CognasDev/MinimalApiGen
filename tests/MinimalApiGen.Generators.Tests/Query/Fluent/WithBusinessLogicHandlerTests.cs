using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.FluentHandlers;
using MinimalApiGen.Generators.Generation.Shared.Results;
using Moq;

namespace MinimalApiGen.Generators.Tests.Query.Fluent;

/// <summary>
/// 
/// </summary>
public sealed class WithHandlerHandlerTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ToHandler_ShouldConvertCorrectly()
    {
        // Arrange
        InvocationExpressionSyntax invocationExpression = SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("TestMethod"));
        Mock<ITypeSymbol> handlerTypeSymbolMock = new();
        handlerTypeSymbolMock.Setup(typeSymbol => typeSymbol.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Namespace.Handler");

        Mock<IMethodSymbol> methodSymbolMock = new();
        methodSymbolMock.Setup(methodSymbol => methodSymbol.TypeArguments).Returns([handlerTypeSymbolMock.Object]);
        methodSymbolMock.Setup(methodSymbol => methodSymbol.Name).Returns("TestMethod");

        Mock<IParameterSymbol> parameterSymbolMock = new();
        parameterSymbolMock.Setup(parameterSymbol => parameterSymbol.Type.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.String");
        methodSymbolMock.Setup(methodSymbol => methodSymbol.Parameters).Returns([parameterSymbolMock.Object]);
        handlerTypeSymbolMock.Setup(typeSymbol => typeSymbol.GetMembers()).Returns([methodSymbolMock.Object]);

        SimpleLambdaExpressionSyntax lambdaExpression = SyntaxFactory.SimpleLambdaExpression
        (
            SyntaxFactory.Parameter(SyntaxFactory.Identifier(string.Empty)),
            SyntaxFactory.IdentifierName("TestMethod")
        );

        ArgumentSyntax argumentSyntax = SyntaxFactory.Argument(lambdaExpression);

        ArgumentListSyntax argumentListSyntax = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList([argumentSyntax]));
        invocationExpression = invocationExpression.WithArgumentList(argumentListSyntax);
        InvocationInfo invocationInfo = new(invocationExpression, methodSymbolMock.Object);

        // Act
        HandlerResult result = invocationInfo.ToHandler();

        // Assert
        result.FullyQualifiedName.Should().Be("Namespace.Handler");
        result.DelegateName.Should().Be("TestMethod");
        result.Parameters.Should().ContainSingle().Which.Should().Be(new HandlerParamterResult { Name = default!, Type = "System.String" });

        #endregion
    }
}