using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators.Query;

/// <summary>
/// 
/// </summary>
public sealed class GetWithServiceAndKeyedService : IntegrationTestBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected override GeneratorType GeneratorType => GeneratorType.Query;

    /// <summary>
    /// 
    /// </summary>
    protected override string Source => @"
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.IntegrationTests.Fixtures;

namespace TestNamespace;

[ApiGenerator]
public sealed class TestGenerator
{
    public TestGenerator()
    {
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IServicesHandler>()
                                          .WithModelId(model => model.Id)
                                          .WithGet()
                                          .WithHandler<IServicesHandler>(logic => logic.GetModelsAsync)
                                          .WithServices<ISampleService1>()
                                          .WithKeyedServices<ISampleService2>(nameof(SampleService2))
                                          .WithResponse<SampleModelResponse>();
    }
}";

    #endregion
}