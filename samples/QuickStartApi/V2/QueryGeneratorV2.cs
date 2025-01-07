﻿using MinimalApiGen.Framework.Generation;
using QuickStartApi.Model;
using QuickStartApi.Services;

namespace QuickStartApi.V2;

/// <summary>
/// 
/// </summary>
[QueryGenerator]
public sealed class QueryGeneratorV2
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public QueryGeneratorV2()
    {
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IBusinessLogicV2>()
                                          .WithGet()
                                                .WithBusinessLogic<IBusinessLogicV2>(logic => logic.GetModelsAsync)
                                                .WithServices<SampleService1, SampleService2>()
                                                .WithKeyedServices<SampleKeyedService>(nameof(SampleKeyedService))
                                                .WithResponse<SampleModelResponse>()
                                                .WithPagination()
                                                .CachedFor(TimeSpan.FromMinutes(3))
                                                .WithVersion(2);
    }

    #endregion
}