using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators;

/// <summary>
/// 
/// </summary>
public sealed class GetById : IntegrationTestBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected override string Source => @"
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Generators.IntegrationTests.Fixtures;
using SampleModel = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel;
namespace TestNamespace;

[QueryGenerator]
public sealed class TestGenerator
{
    public TestGenerator()
    {
var d = new SampleModel();
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<ISimpleBusinessLogic>()
                                          .WithModelId(model => model.Id)
                                          .WithGetById()
                                          .WithBusinessLogic<ISimpleBusinessLogic>(logic => logic.GetModelByIdAsync)
                                          .WithResponse<SampleModelResponse>();
    }
}";

    #endregion
}