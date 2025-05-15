using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class TracksCommandGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public TracksCommandGenerator()
    {
        ApiGeneration.Command<Track>().WithNamespaceOf<ITracksCommandHandler>()
                                      .WithModelId(model => model.TrackId)
                                      .WithPost()
                                            .WithHandler<ITracksCommandHandler>(command => command.InsertTrackAsync)
                                            .WithRequest<TrackRequest>()
                                            .WithFluentValidation()
                                            .WithRequestMappingService()
                                            .WithResponse<TrackResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Track>().WithNamespaceOf<ITracksCommandHandler>()
                                      .WithModelId(model => model.TrackId)
                                      .WithPut()
                                          .WithHandler<ITracksCommandHandler>(command => command.UpdateTrackAsync)
                                          .WithRequest<TrackRequest>()
                                          .WithFluentValidation()
                                          .WithRequestMappingService()
                                          .WithResponse<TrackResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Track>().WithNamespaceOf<ITracksCommandHandler>()
                                      .WithModelId(model => model.TrackId)
                                      .WithDelete()
                                            .WithHandler<ITracksCommandHandler>(command => command.DeleteTrackAsync)
                                            .WithRequest<TrackRequest>();

    }

    #endregion
}