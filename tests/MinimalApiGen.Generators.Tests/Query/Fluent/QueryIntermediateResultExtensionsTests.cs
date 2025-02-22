using FluentAssertions;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Query.Fluent;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using Moq;

namespace MinimalApiGen.Generators.Tests.Query.Fluent;

/// <summary>
/// 
/// </summary>
public sealed class QueryIntermediateResultExtensionsTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void InitialiseQueryIntermediateResult_ShouldInitializeCorrectly()
    {
        // Arrange
        InvocationResult queryInvocationDetails = new()
        {
            ModelName = "Model",
            ModelPluralName = "Models",
            ModelFullyQualifiedName = "Namespace.Model"
        };

        // Act
        QueryIntermediateResult result = queryInvocationDetails.InitialiseQueryIntermediateResult(It.IsAny<OperationType>());

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
            OperationType = OperationType.Get
        };

        // Act
        queryIntermediateResults.TryFinaliseAndCollectIntermediateResult(queryIntermediateResult, "QueryNamespace", It.IsAny<ModelIdPropertyResult>());

        // Assert
        queryIntermediateResults.Should().ContainSingle();
        queryIntermediateResults[0].QueryNamespace.Should().Be("QueryNamespace");
    }

    #endregion
}