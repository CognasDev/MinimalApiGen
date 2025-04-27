using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class TracksCommandHandler(ILogger<TracksCommandHandler> logger, ICommandDatabaseService databaseService)
    : CommandHandlerBase<Track>(logger, databaseService), ITracksCommandHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Track> InsertTrackAsync(Track album) => await InsertModelAsync(album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Track> UpdateTrackAsync(Track album) => await UpdateModelAsync(album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteTrackAsync(int id)
    {
        ModelParameter<Track> parameter = new(track => track.TrackId, id);
        await DeleteModelAsync(parameter);
    }

    #endregion
}