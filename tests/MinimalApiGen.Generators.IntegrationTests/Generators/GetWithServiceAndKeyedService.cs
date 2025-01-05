using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators;

/// <summary>
/// 
/// </summary>
public sealed class GetWithServiceAndKeyedService : IntegrationTestBase
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
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IServicesBusinessLogic>()
                                          .WithGet()
                                          .WithBusinessLogic<IServicesBusinessLogic>(logic => logic.GetModelsAsync)
                                          .WithServices<ISampleService1>()
                                          .WithKeyedServices<ISampleService2>(nameof(SampleService2))
                                          .WithResponse<SampleModelResponse>();
    }
}";

    #endregion
}