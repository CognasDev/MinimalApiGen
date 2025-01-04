using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Query.FluentHandlers;
using MinimalApiGen.Generators.Query.Invocation;
using Moq;

namespace MinimalApiGen.Generators.Tests.Query.Fluent;

/// <summary>
/// 
/// </summary>
public sealed class WithServicesHandlerTests
{
    #region Unit Test Method Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ToServices_ShouldReturnFullyQualifiedNames()
    {
        // Arrange
        Mock<ITypeSymbol> typeSymbolMock1 = new();
        typeSymbolMock1.Setup(typeSymbol => typeSymbol.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Namespace.Type1");

        Mock<ITypeSymbol> typeSymbolMock2 = new();
        typeSymbolMock2.Setup(typeSymbol => typeSymbol.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Namespace.Type2");

        ITypeSymbol[] typeSymbols = [typeSymbolMock1.Object, typeSymbolMock2.Object];
        Mock<IMethodSymbol> methodSymbolMock = new();
        methodSymbolMock.Setup(methodSymbol => methodSymbol.TypeArguments).Returns([.. typeSymbols]);

        InvocationInfo invocationInfo = new(It.IsAny<InvocationExpressionSyntax>(), methodSymbolMock.Object);

        // Act
        IReadOnlyList<string> result = invocationInfo.ToServices();

        // Assert
        result.Should().BeEquivalentTo(new List<string> { "Namespace.Type1", "Namespace.Type2" });
    }

    #endregion
}