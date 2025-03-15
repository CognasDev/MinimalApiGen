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
        ApiGeneration.Query<SampleModel>().WithNamespaceOf<IQueryHandlerV1>()
                                          .WithModelId(model => model.Id)
                                          .WithGet()
                                                .WithHandler<IQueryHandlerV1>(query => query.GetModelsAsync)
                                                .WithJwtAuthentication()
                                                .WithResponse<SampleModelResponse>()
                                                .WithMappingService()
                                                .WithVersion(1)
                                          .WithGetById()
                                                .WithHandler<IQueryHandlerV1>(query => query.GetModelByIdAsync)
                                                .WithJwtAuthentication("Test")
                                                .WithResponse<SampleModelResponse>()
                                                .WithMappingService()
                                                .WithVersion(1);

    }

    #endregion
}