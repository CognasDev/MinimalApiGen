using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators;

/// <summary>
/// 
/// </summary>
public sealed class GetWithService : IntegrationTestBase
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
                                          .WithServices<ISampleService1>()
                                          .WithResponse<SampleModelResponse>();
    }
}";

    #endregion
}