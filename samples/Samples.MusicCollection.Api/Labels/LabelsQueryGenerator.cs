using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class LabelsQueryGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public LabelsQueryGenerator()
    {
        ApiGeneration.Query<Label>().WithNamespaceOf<ILabelsQueryHandler>()
                                     .WithModelId(model => model.LabelId)
                                     .WithGet()
                                         .WithHandler<ILabelsQueryHandler>(query => query.SelectLabelsAsync)
                                         .WithResponse<LabelResponse>()
                                         .WithPagination()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithHandler<ILabelsQueryHandler>(query => query.SelectLabelAsync)
                                         .WithResponse<LabelResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}