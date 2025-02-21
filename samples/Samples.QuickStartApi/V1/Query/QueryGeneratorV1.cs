using MinimalApiGen.Framework.Generation;
using Samples.QuickStartApi.V1.Model;

namespace Samples.QuickStartApi.V1.Query;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class QueryGeneratorV1
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public QueryGeneratorV1()
    {
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IQueryBusinessLogicV1>()
                                          .WithModelId(model => model.Id)
                                          .WithGet()
                                                .WithBusinessLogic<IQueryBusinessLogicV1>(query => query.GetModelsAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .WithMappingService()
                                                .WithVersion(1)
                                          .WithGetById()
                                                .WithBusinessLogic<IQueryBusinessLogicV1>(query => query.GetModelByIdAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .WithMappingService()
                                                .WithVersion(1);

    }

    #endregion
}