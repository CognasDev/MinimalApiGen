﻿using MinimalApiGen.Generators.IntegrationTests.Helpers;

namespace MinimalApiGen.Generators.IntegrationTests.Generators.Query;

/// <summary>
/// 
/// </summary>
public sealed class GetById : IntegrationTestBase
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
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<ISimpleBusinessLogic>()
                                          .WithModelId(model => model.Id)
                                          .WithGetById()
                                          .WithBusinessLogic<ISimpleBusinessLogic>(logic => logic.GetModelByIdAsync)
                                          .WithResponse<SampleModelResponse>();
    }
}";

    #endregion
}