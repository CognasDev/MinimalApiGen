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
        ApiGeneration.Query<Track>().WithNamespaceOf<ITracksQueryHandler>()
                                     .WithModelId(track => track.TrackId)
                                     .WithGet()
                                         .WithHandler<ITracksQueryHandler>(query => query.SelectTracksAsync)
                                         .WithQueryParameters<Track>(track => track.AlbumId)
                                         .WithResponse<TrackResponse>()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithHandler<ITracksQueryHandler>(query => query.SelectTrackAsync)
                                         .WithResponse<TrackResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}