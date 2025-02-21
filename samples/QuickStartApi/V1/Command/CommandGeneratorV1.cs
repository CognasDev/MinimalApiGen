using MinimalApiGen.Framework.Generation;
using QuickStartApi.V1.Model;

namespace QuickStartApi.V1.Command;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class CommandGeneratorV1
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public CommandGeneratorV1()
    {
        ApiGeneration.Command<SampleModel>().WithNamespaceOf<CommandGeneratorV1>()
                                            .WithModelId(model => model.Id)
                                            .WithPost()
                                                .WithBusinessLogic<ICommandBusinessLogicV1>(command => command.PostModelAsync)
                                                .WithRequest<SampleModelRequest>()
                                                .WithRequestMappingService()
                                                .WithResponse<SampleModelResponse>()
                                                .WithResponseMappingService();

        ApiGeneration.Command<SampleModel>().WithNamespaceOf<CommandGeneratorV1>()
                                            .WithModelId(model => model.Id)
                                            .WithPut()
                                                .WithBusinessLogic<ICommandBusinessLogicV1>(command => command.PutModelAsync)
                                                .WithRequest<SampleModelRequest>()
                                                .WithRequestMappingService()
                                                .WithResponse<SampleModelResponse>()
                                                .WithResponseMappingService();


    }

    #endregion
}