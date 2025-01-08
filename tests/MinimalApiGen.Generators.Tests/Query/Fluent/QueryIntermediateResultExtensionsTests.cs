using FluentAssertions;
using MinimalApiGen.Generators.Generation.Query;
using MinimalApiGen.Generators.Generation.Query.Fluent;
using MinimalApiGen.Generators.Generation.Query.Invocation;
using MinimalApiGen.Generators.Generation.Query.Results;
using Moq;

namespace MinimalApiGen.Generators.Tests.Query.Fluent;

/// <summary>
/// 
/// </summary>
public sealed class QueryIntermediateResultExtensionsTests
{
    #region Unit Test Method Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void InitialiseQueryIntermediateResult_ShouldInitializeCorrectly()
    {
        // Arrange
        QueryInvocationDetails queryInvocationDetails = new()
        {
            ModelName = "Model",
            ModelPluralName = "Models",
            ModelFullyQualifiedName = "Namespace.Model"
        };

        // Act
        QueryIntermediateResult result = queryInvocationDetails.InitialiseQueryIntermediateResult(It.IsAny<QueryType>());

        // Assert
        result.ModelName.Should().Be("Model");
        result.ModelPluralName.Should().Be("Models");
        result.ModelFullyQualifiedName.Should().Be("Namespace.Model");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void TryFinaliseAndCollectIntermediateResult_ShouldAddToListWhenNotNull()
    {
        // Arrange
        List<QueryIntermediateResult> queryIntermediateResults = [];
        QueryIntermediateResult queryIntermediateResult = new()
        {
            ModelName = "Model",
            ModelPluralName = "Models",
            ModelFullyQualifiedName = "Namespace.Model",
            QueryType = QueryType.Get
        };

        // Act
        queryIntermediateResults.TryFinaliseAndCollectIntermediateResult(queryIntermediateResult, "QueryNamespace");

        // Assert
        queryIntermediateResults.Should().ContainSingle();
        queryIntermediateResults[0].QueryNamespace.Should().Be("QueryNamespace");
    }

    #endregion
}