using FluentAssertions;
using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Query;
using MinimalApiGen.Generators.Generation.Query.Results;

namespace MinimalApiGen.Generators.Tests.Query.Results;

/// <summary>
/// 
/// </summary>
public sealed class QueryResultTests
{
    #region Unit Test Method Declarations

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
            QueryType = QueryType.Get,
            QueryNamespace = "Namespace",
            ResponseResult = new WithResponseResult
            {
                ResponseName = "TestResponse",
                ResponseFullyQualifiedName = "Namespace.TestResponse"
            },
            BusinessLogicResult = new BusinessLogicResult
            {
                FullyQualifiedName = "Namespace.BusinessLogic",
                DelegateName = "BusinessLogicDelegate",
                Parameters = { "param1", "param2" }
            },
            Services = { "Service1", "Service2" },
            KeyedServices = { ["Key1"] = "Value1", ["Key2"] = "Value2" },
            Version = 2,
            WithPagination = true
        };

        // Act
        QueryResult queryResult = new(queryIntermediateResult);

        // Assert
        queryResult.QueryType.Should().Be(QueryType.Get);
        queryResult.ClassNamespace.Should().Be("Namespace");
        queryResult.ModelName.Should().Be("TestModel");
        queryResult.ModelPluralName.Should().Be("TestModels");
        queryResult.ModelFullyQualifiedName.Should().Be("Namespace.TestModel");
        queryResult.ResponseName.Should().Be("TestResponse");
        queryResult.ResponseFullyQualifiedName.Should().Be("Namespace.TestResponse");
        queryResult.WithPagination.Should().BeTrue();
        queryResult.Services.Should().BeEquivalentTo(new EquatableArray<string>(["Service1", "Service2"]));
        queryResult.Version.Should().Be(2);
        queryResult.KeyedServices.Should().BeEquivalentTo(new EquatableDictionary<string, string>(new Dictionary<string, string> { ["Key1"] = "Value1", ["Key2"] = "Value2" }));
        queryResult.BusinessLogicFullyQualifiedName.Should().Be("Namespace.BusinessLogic");
        queryResult.BusinessLogicDelegateName.Should().Be("BusinessLogicDelegate");
        queryResult.BusinessLogicParameters.Should().BeEquivalentTo(new EquatableArray<string>(["param1", "param2"]));
    }

    #endregion
}