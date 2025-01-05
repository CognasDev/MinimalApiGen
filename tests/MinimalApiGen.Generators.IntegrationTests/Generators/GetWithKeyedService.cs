using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators;

/// <summary>
/// 
/// </summary>
public sealed class GetWithKeyedService : IntegrationTestBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected override string Source => @"
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.IntegrationTests.Fixtures;

namespace TestNamespace;

[QueryGenerator]
public sealed class TestGenerator
{
    public TestGenerator()
    {
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IServiceBusinessLogic>()
                                          .WithGet()
                                          .WithBusinessLogic<IServiceBusinessLogic>(logic => logic.GetModelsAsync)
                                          .WithKeyedServices<ISampleService1>(nameof(SampleService1))
                                          .WithResponse<SampleModelResponse>();
    }
}";

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override async Task VerifySnapshot() => await VerifySnapshotAsync(nameof(GetWithKeyedService));

    #endregion
}