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
        ApiGeneration.Command<Label>().WithNamespaceOf<ILabelsCommandHandler>()
                                      .WithModelId(model => model.LabelId)
                                      .WithPost()
                                            .WithHandler<ILabelsCommandHandler>(command => command.InsertLabelAsync)
                                            .WithRequest<LabelRequest>()
                                            .WithFluentValidation()
                                            .WithRequestMappingService()
                                            .WithResponse<LabelResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Label>().WithNamespaceOf<ILabelsCommandHandler>()
                                      .WithModelId(model => model.LabelId)
                                      .WithPut()
                                          .WithHandler<ILabelsCommandHandler>(command => command.UpdateLabelAsync)
                                          .WithRequest<LabelRequest>()
                                          .WithFluentValidation()
                                          .WithRequestMappingService()
                                          .WithResponse<LabelResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Label>().WithNamespaceOf<ILabelsCommandHandler>()
                                      .WithModelId(model => model.LabelId)
                                      .WithDelete()
                                            .WithHandler<ILabelsCommandHandler>(command => command.DeleteLabelAsync)
                                            .WithRequest<LabelRequest>();

    }

    #endregion
}