using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators;

/// <summary>
/// 
/// </summary>
public sealed class GetAndGetByIdChain : IntegrationTestBase
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
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<ISimpleBusinessLogic>()
                                          .WithModelId(model => model.Id)
                                          .WithGet()
                                                .WithBusinessLogic<ISimpleBusinessLogic>(logic => logic.GetModelsAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .WithVersion(3)
                                          .WithGetById()
                                                .WithBusinessLogic<ISimpleBusinessLogic>(logic => logic.GetModelByIdAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .WithVersion(3);
    }
}";

    #endregion
}