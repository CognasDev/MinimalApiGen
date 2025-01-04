using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Query.FluentHandlers;
using MinimalApiGen.Generators.Query.Invocation;
using MinimalApiGen.Generators.Query.Results;
using Moq;

namespace MinimalApiGen.Generators.Tests.Query.Fluent;

/// <summary>
/// 
/// </summary>
public sealed class WithResponseHandlerTests
{
    #region Unit Test Method Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ToResponse_ShouldReturnCorrectResponseResult()
    {
        // Arrange
        Mock<ITypeSymbol> typeSymbolMock = new();
        typeSymbolMock.Setup(typeSymbol => typeSymbol.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Namespace.ResponseType");
        typeSymbolMock.Setup(typeSymbol => typeSymbol.Name).Returns("ResponseType");

        Mock<IMethodSymbol> methodSymbolMock = new();
        methodSymbolMock.Setup(methodSymbol => methodSymbol.TypeArguments).Returns([typeSymbolMock.Object]);

        InvocationExpressionSyntax invocationExpressionSyntax = SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("TestMethod"));
        InvocationInfo invocationInfo = new(invocationExpressionSyntax, methodSymbolMock.Object);

        // Act
        WithResponseResult result = invocationInfo.ToResponse();

        // Assert
        result.ResponseFullyQualifiedName.Should().Be("Namespace.ResponseType");
        result.ResponseName.Should().Be("ResponseType");
    }

    #endregion
}