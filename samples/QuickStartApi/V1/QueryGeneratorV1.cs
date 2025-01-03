using MinimalApiGen.Framework.Generation;
using QuickStartApi.Model;
using QuickStartApi.Services;

namespace QuickStartApi.V1;

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
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IBusinessLogicV1>()
                                          .WithGet()
                                                .WithBusinessLogic<IBusinessLogicV1>(logic => logic.GetModelsV1Async)
                                                .WithServices<SampleService1>()
                                                .WithResponse<SampleModelResponse>()
                                                .WithMappingService();
    }

    #endregion
}