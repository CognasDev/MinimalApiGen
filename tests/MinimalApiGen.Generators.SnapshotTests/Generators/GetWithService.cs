using Microsoft.CodeAnalysis;
using MinimalApiGen.Generators.SnapshotTests.Helpers;

namespace MinimalApiGen.Generators.SnapshotTests.Generators;

/// <summary>
/// 
/// </summary>
[UsesVerify]
public sealed class GetWithService
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
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IServiceBusinessLogic>()
                                          .WithGet()
                                          .WithBusinessLogic<IServiceBusinessLogic>(logic => logic.GetModelsAsync)
                                          .WithServices<ISampleService>()
                                          .WithResponse<SampleModelResponse>();
    }
}";

        await SnapshotHelper.VerifyAsync(source, nameof(GetWithService));
    }

    #endregion
}