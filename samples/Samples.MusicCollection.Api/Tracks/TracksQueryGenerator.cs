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
                                     .WithModelId(model => model.TrackId)
                                     .WithGet()
                                         .WithBusinessLogic<ITracksQueryBusinessLogic>(query => query.SelectTracksAsync)
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