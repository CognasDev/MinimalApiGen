using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Shared;
using Moq;

namespace MinimalApiGen.Generators.Tests.Query.Invocation;

/// <summary>
/// 
/// </summary>
public sealed class InvocationExtensionsTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetSingleArgumentExpression_ShouldReturnSingleArgumentExpression()
    {
        // Arrange
        LiteralExpressionSyntax argumentExpression = SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(1));
        ArgumentSyntax argument = SyntaxFactory.Argument(argumentExpression);
        ArgumentListSyntax argumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList([argument]));
        InvocationExpressionSyntax invocationExpression = SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName("TestMethod"), argumentList);
        InvocationInfo invocationInfo = new(invocationExpression, Mock.Of<IMethodSymbol>());

        // Act
        ExpressionSyntax result = invocationInfo.GetSingleArgumentExpression();

        // Assert
        result.Should().BeOfType<LiteralExpressionSyntax>();
        LiteralExpressionSyntax literalExpressionSyntax = (LiteralExpressionSyntax)result;
        literalExpressionSyntax.Token.Value.Should().Be(1);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void GetPublicProperties_ShouldReturnPublicProperties()
    {
        // Arrange
        Mock<IPropertySymbol> propertySymbolMock = new();
        propertySymbolMock.Setup(propertySymbol => propertySymbol.DeclaredAccessibility).Returns(Accessibility.Public);
        propertySymbolMock.Setup(propertySymbol => propertySymbol.Name).Returns("TestProperty");
        Mock<ITypeSymbol> typeSymbolMock = new();
        typeSymbolMock.Setup(typeSymbol => typeSymbol.GetMembers()).Returns([propertySymbolMock.Object]);

        // Act
        IReadOnlyList<string> result = typeSymbolMock.Object.GetPublicProperties();

        // Assert
        result.Should().ContainSingle().Which.Should().Be("TestProperty");
    }

    #endregion
}