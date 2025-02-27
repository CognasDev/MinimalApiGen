using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class TracksQueryGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public TracksQueryGenerator()
    {
        ApiGeneration.Query<Track>().WithNamespaceOf<ITracksQueryBusinessLogic>()
                                     .WithModelId(track => track.TrackId)
                                     .WithGet()
                                         .WithBusinessLogic<ITracksQueryBusinessLogic>(query => query.SelectTracksAsync)
                                         .WithQueryParameters<Track>(track => track.AlbumId)
                                         .WithResponse<TrackResponse>()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithBusinessLogic<ITracksQueryBusinessLogic>(query => query.SelectTrackAsync)
                                         .WithResponse<TrackResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}