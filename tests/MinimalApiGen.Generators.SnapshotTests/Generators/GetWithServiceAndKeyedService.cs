using MinimalApiGen.Generators.SnapshotTests.Helpers;

namespace MinimalApiGen.Generators.SnapshotTests.Generators;

/// <summary>
/// 
/// </summary>
[UsesVerify]
public sealed class GetWithServiceAndKeyedService
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task Test()
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
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IServicesBusinessLogic>()
                                          .WithGet()
                                          .WithBusinessLogic<IServicesBusinessLogic>(logic => logic.GetModelsAsync)
                                          .WithServices<ISampleService1>()
                                          .WithKeyedServices<ISampleService2>(nameof(SampleService2))
                                          .WithResponse<SampleModelResponse>();
    }
}";

        await SnapshotHelper.VerifyAsync(source, nameof(GetWithServiceAndKeyedService));
    }

    #endregion
}