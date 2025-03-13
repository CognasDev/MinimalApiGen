using FluentAssertions;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Query.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;

namespace MinimalApiGen.Generators.Tests.Query.Results;

/// <summary>
/// 
/// </summary>
public sealed class QueryResultTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void QueryResult_ShouldInitializeFieldsCorrectly()
    {
        // Arrange
        QueryIntermediateResult queryIntermediateResult = new()
        {
            ModelName = "TestModel",
            ModelPluralName = "TestModels",
            ModelFullyQualifiedName = "Namespace.TestModel",
            OperationType = OperationType.Get,
            QueryNamespace = "Namespace",
            ResponseResult = new WithResponseResult
            {
                ResponseName = "TestResponse",
                ResponseFullyQualifiedName = "Namespace.TestResponse"
            },
            HandlerResult = new HandlerResult
            {
                FullyQualifiedName = "Namespace.Handler",
                DelegateName = "HandlerDelegate"
            },
            Services = { "Service1", "Service2" },
            KeyedServices = { ["Key1"] = "Value1", ["Key2"] = "Value2" },
            Version = 2,
            WithPagination = true
        };

        // Act
        QueryResult queryResult = new(queryIntermediateResult);

        // Assert
        queryResult.OperationType.Should().Be(OperationType.Get);
        queryResult.ClassNamespace.Should().Be("Namespace");
        queryResult.ModelName.Should().Be("TestModel");
        queryResult.ModelPluralName.Should().Be("TestModels");
        queryResult.ModelFullyQualifiedName.Should().Be("Namespace.TestModel");
        queryResult.ResponseName.Should().Be("TestResponse");
        queryResult.ResponseFullyQualifiedName.Should().Be("Namespace.TestResponse");
        queryResult.WithPagination.Should().BeTrue();
        queryResult.Services.Should().BeEquivalentTo(new EquatableArray<string>(["Service1", "Service2"]));
        queryResult.ApiVersion.Should().Be(2);
        queryResult.KeyedServices.Should().BeEquivalentTo(new EquatableDictionary<string, string>(new Dictionary<string, string> { ["Key1"] = "Value1", ["Key2"] = "Value2" }));
        queryResult.HandlerFullyQualifiedName.Should().Be("Namespace.Handler");
        queryResult.HandlerDelegateName.Should().Be("HandlerDelegate");
    }

    #endregion
}