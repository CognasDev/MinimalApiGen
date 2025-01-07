using MinimalApiGen.Framework.Generation;
using QuickStartApi.Model;

namespace QuickStartApi.V3;

/// <summary>
/// 
/// </summary>
[QueryGenerator]
public sealed class QueryGeneratorV3
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public QueryGeneratorV3()
    {
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IBusinessLogicV3>()
                                          .WithGet()
                                                .WithBusinessLogic<IBusinessLogicV3>(logic => logic.GetModelsAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .WithVersion(3)
                                          .WithGetById()
                                                .WithBusinessLogic<IBusinessLogicV3>(logic => logic.GetModelByIdAsync)
                                                .WithResponse<SampleModelResponse>()
                                                .CachedFor(TimeSpan.FromMinutes(5))
                                                .WithVersion(3);
    }

    #endregion
}