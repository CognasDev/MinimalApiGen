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
        ApiGeneration.Query<Label>().WithNamespaceOf<ILabelsQueryBusinessLogic>()
                                     .WithModelId(model => model.LabelId)
                                     .WithGet()
                                         .WithBusinessLogic<ILabelsQueryBusinessLogic>(query => query.SelectLabelsAsync)
                                         .WithResponse<LabelResponse>()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithBusinessLogic<ILabelsQueryBusinessLogic>(query => query.SelectLabelAsync)
                                         .WithResponse<LabelResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}