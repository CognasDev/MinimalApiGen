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
        ApiGeneration.Command<Track>().WithNamespaceOf<ITracksCommandBusinessLogic>()
                                      .WithModelId(model => model.TrackId)
                                      .WithPost()
                                            .WithBusinessLogic<ITracksCommandBusinessLogic>(command => command.InsertTrackAsync)
                                            .WithRequest<TrackRequest>()
                                            .WithRequestMappingService()
                                            .WithResponse<TrackResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Track>().WithNamespaceOf<ITracksCommandBusinessLogic>()
                                      .WithModelId(model => model.TrackId)
                                      .WithPut()
                                          .WithBusinessLogic<ITracksCommandBusinessLogic>(command => command.UpdateTrackAsync)
                                          .WithRequest<TrackRequest>()
                                          .WithRequestMappingService()
                                          .WithResponse<TrackResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Track>().WithNamespaceOf<ITracksCommandBusinessLogic>()
                                      .WithModelId(model => model.TrackId)
                                      .WithDelete()
                                            .WithBusinessLogic<ITracksCommandBusinessLogic>(command => command.DeleteTrackAsync);

    }

    #endregion
}