using MinimalApiGen.Framework.Generation;
using QuickStartApi.V1.Model;

namespace QuickStartApi.V1.Query;

/// <summary>
/// 
/// </summary>
[QueryGenerator]
public sealed class QueryGeneratorV1
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public QueryGeneratorV1()
    {
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IQueryBusinessLogicV1>()
                                          .WithGet()
                                                .WithBusinessLogic<IQueryBusinessLogicV1>(query => query.GetModelsAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .WithMappingService()
                                                .WithVersion(1)
                                          .WithGetById()
                                                .WithBusinessLogic<IQueryBusinessLogicV1>(query => query.GetModelByIdAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .CachedFor(TimeSpan.FromMinutes(5))
                                                .WithVersion(1);
    }

    #endregion
}