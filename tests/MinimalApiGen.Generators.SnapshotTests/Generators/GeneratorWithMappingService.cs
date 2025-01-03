using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.SnapshotTests.Helpers;

namespace MinimalApiGen.Generators.SnapshotTests.Generators;

/// <summary>
/// 
/// </summary>
[UsesVerify]
public sealed class GeneratorWithMappingService
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public Task Test()
    {
        string source = @"
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.SnapshotTests.Fixtures;

namespace TestNamespace;

[QueryGenerator]
public sealed class TestGenerator
{
    public TestGenerator()
    {
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IBusinessLogicV1>()
                                          .WithGet()
                                                .WithBusinessLogic<IBusinessLogicV1>(logic => logic.GetModelsV1Async)
                                                .WithServices<SampleService1>()
                                                .WithResponse<SampleModelResponse>()
                                                .WithMappingService();
    }
}";
        GeneratorDriver driver = DriverBuilder.Build(source);
        return Verifier.Verify(driver).UseDirectory("../Snapshots");
    }

    #endregion
}