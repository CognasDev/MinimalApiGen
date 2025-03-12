using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators.Command;

/// <summary>
/// 
/// </summary>
public sealed class Delete : IntegrationTestBase
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    protected override GeneratorType GeneratorType => GeneratorType.Command;

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
        ApiGeneration.Command<SampleModel>().WithNamespaceOf<TestGenerator>()
                                            .WithModelId(model => model.Id)
                                            .WithDelete()
                                                .WithBusinessLogic<ISimpleBusinessLogic>(command => command.DeleteModelAsync)
                                                .WithJwtAuthentication()
                                                .WithRequest<SampleModelRequest>()
                                                .WithRequestMappingService();
    }
}";

    #endregion
}