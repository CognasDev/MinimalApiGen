using FluentAssertions;
using MinimalApiGen.Generators.Query.Fluent;
using MinimalApiGen.Generators.Query.Invocation;
using MinimalApiGen.Generators.Query.Results;

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
        QueryIntermediateResult result = queryInvocationDetails.InitialiseQueryIntermediateResult();

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
            ModelFullyQualifiedName = "Namespace.Model"
        };

        // Act
        queryIntermediateResults.TryFinaliseAndCollectIntermediateResult(queryIntermediateResult, "MasterNamespace", "ClassNamespace");

        // Assert
        queryIntermediateResults.Should().ContainSingle();
        queryIntermediateResults[0].ClassNamespace.Should().Be("ClassNamespace");
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void TryFinaliseAndCollectIntermediateResult_ShouldUseMasterNamespaceWhenClassNamespaceIsEmpty()
    {
        // Arrange
        List<QueryIntermediateResult> queryIntermediateResults = [];
        QueryIntermediateResult queryIntermediateResult = new()
        {
            ModelName = "Model",
            ModelPluralName = "Models",
            ModelFullyQualifiedName = "Namespace.Model"
        };

        // Act
        queryIntermediateResults.TryFinaliseAndCollectIntermediateResult(queryIntermediateResult, "MasterNamespace", string.Empty);

        // Assert
        queryIntermediateResults.Should().ContainSingle();
        queryIntermediateResults[0].ClassNamespace.Should().Be("MasterNamespace");
    }

    #endregion
}