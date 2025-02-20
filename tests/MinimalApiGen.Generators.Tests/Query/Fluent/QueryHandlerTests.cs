using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MinimalApiGen.Generators.Generation.Query.Fluent;
using MinimalApiGen.Generators.Generation.Query.FluentHandlers;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using Moq;
using System.Collections.Immutable;

namespace MinimalApiGen.Generators.Tests.Query.Fluent;

/// <summary>
/// 
/// </summary>
public sealed class QueryHandlerTests
{
    #region Unit Test Method Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void ToQueryInvocationDetails_ShouldReturnCorrectDetails()
    {
        // Arrange
        Mock<IMethodSymbol> methodSymbolMock = new();
        methodSymbolMock.Setup(methodSymbol => methodSymbol.ConstructedFrom.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns(QueryMethodNames.Query);
        Mock<ITypeSymbol> typeSymbolMock = new();
        typeSymbolMock.Setup(typeSymbol => typeSymbol.Name).Returns("TestModel");
        typeSymbolMock.Setup(typeSymbol => typeSymbol.ToDisplayString(It.IsAny<SymbolDisplayFormat>())).Returns("Namespace.TestModel");

        MockGetPublicProperties(typeSymbolMock);

        methodSymbolMock.Setup(methodSymbol => methodSymbol.TypeArguments).Returns([typeSymbolMock.Object]);

        InvocationInfo invocationInfo = new(It.IsAny<InvocationExpressionSyntax>(), methodSymbolMock.Object);
        ImmutableArray<InvocationInfo> invocations = [invocationInfo];

        // Act
        InvocationResult result = invocations.ToInvocationResult();

        // Assert
        result.ModelName.Should().Be("TestModel");
        result.ModelPluralName.Should().Be("TestModels");
        result.ModelFullyQualifiedName.Should().Be("Namespace.TestModel");
        result.PropertyNames.Should().Contain(["Property1", "Property2"]);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// Mocks the <see cref="InvocationExtensions.GetPublicProperties(ITypeSymbol)"/> extension method.
    /// </summary>
    /// <param name="typeSymbolMock"></param>
    private static void MockGetPublicProperties(Mock<ITypeSymbol> typeSymbolMock)
    {
        List<string> properties = ["Property1", "Property2"];
        IEnumerable<ISymbol> propertySymbolMocks = properties.Select(propertySymbolMock =>
        {
            return Mock.Of<IPropertySymbol>(property => property.Name == propertySymbolMock && property.DeclaredAccessibility == Accessibility.Public);
        });
        ImmutableArray<ISymbol> propertySymbols = propertySymbolMocks.ToImmutableArray();
        typeSymbolMock.Setup(typeSymbol => typeSymbol.GetMembers()).Returns(propertySymbols);
    }

    #endregion
}