using MinimalApiGen.Framework.Generation;
using Samples.QuickStartApi.V1.Model;

namespace Samples.QuickStartApi.V1.Command;

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
                                                .WithHandler<ICommandHandlerV1>(command => command.PostModelAsync)
                                                .WithJwtAuthentication("ExampleRole")
                                                .WithRequest<SampleModelRequest>()
                                                .WithRequestMappingService()
                                                .WithResponse<SampleModelResponse>()
                                                .WithResponseMappingService();

        ApiGeneration.Command<SampleModel>().WithNamespaceOf<CommandGeneratorV1>()
                                            .WithModelId(model => model.Id)
                                            .WithPut()
                                                .WithHandler<ICommandHandlerV1>(command => command.PutModelAsync)
                                                .WithJwtAuthentication()
                                                .WithRequest<SampleModelRequest>()
                                                .WithRequestMappingService()
                                                .WithResponse<SampleModelResponse>()
                                                .WithResponseMappingService();

        ApiGeneration.Command<SampleModel>().WithNamespaceOf<CommandGeneratorV1>()
                                            .WithModelId(model => model.Id)
                                            .WithDelete()
                                                .WithHandler<ICommandHandlerV1>(command => command.DeleteModelAsync)
                                                .WithRequest<SampleModelRequest>()
                                                .WithJwtAuthentication()
                                                .WithVersion(2);


    }

    #endregion
}