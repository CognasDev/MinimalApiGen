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
public sealed class WithBusinessLogicHandlerTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ToBusinessLogic_ShouldConvertCorrectly()
    {
        // Arrange
        InvocationExpressionSyntax invocationExpression = SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("TestMethod"));
        Mock<ITypeSymbol> businessLogicTypeSymbolMock = new();
        businessLogicTypeSymbolMock.Setup(typeSymbol => typeSymbol.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Namespace.BusinessLogic");

        Mock<IMethodSymbol> methodSymbolMock = new();
        methodSymbolMock.Setup(methodSymbol => methodSymbol.TypeArguments).Returns([businessLogicTypeSymbolMock.Object]);
        methodSymbolMock.Setup(methodSymbol => methodSymbol.Name).Returns("TestMethod");

        Mock<IParameterSymbol> parameterSymbolMock = new();
        parameterSymbolMock.Setup(parameterSymbol => parameterSymbol.Type.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("System.String");
        methodSymbolMock.Setup(methodSymbol => methodSymbol.Parameters).Returns([parameterSymbolMock.Object]);
        businessLogicTypeSymbolMock.Setup(typeSymbol => typeSymbol.GetMembers()).Returns([methodSymbolMock.Object]);

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
        BusinessLogicResult result = invocationInfo.ToBusinessLogic();

        // Assert
        result.FullyQualifiedName.Should().Be("Namespace.BusinessLogic");
        result.DelegateName.Should().Be("TestMethod");
        result.Parameters.Should().ContainSingle().Which.Should().Be("System.String");

        #endregion
    }
}