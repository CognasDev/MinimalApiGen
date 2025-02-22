using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class LabelsCommandGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public LabelsCommandGenerator()
    {
        ApiGeneration.Command<Label>().WithNamespaceOf<ILabelsCommandBusinessLogic>()
                                      .WithModelId(model => model.LabelId)
                                      .WithPost()
                                            .WithBusinessLogic<ILabelsCommandBusinessLogic>(command => command.InsertLabelAsync)
                                            .WithRequest<LabelRequest>()
                                            .WithRequestMappingService()
                                            .WithResponse<LabelResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Label>().WithNamespaceOf<ILabelsCommandBusinessLogic>()
                                      .WithModelId(model => model.LabelId)
                                      .WithPut()
                                          .WithBusinessLogic<ILabelsCommandBusinessLogic>(command => command.UpdateLabelAsync)
                                          .WithRequest<LabelRequest>()
                                          .WithRequestMappingService()
                                          .WithResponse<LabelResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Label>().WithNamespaceOf<ILabelsCommandBusinessLogic>()
                                      .WithModelId(model => model.LabelId)
                                      .WithDelete()
                                            .WithBusinessLogic<ILabelsCommandBusinessLogic>(command => command.DeleteLabelAsync);

    }

    #endregion
}