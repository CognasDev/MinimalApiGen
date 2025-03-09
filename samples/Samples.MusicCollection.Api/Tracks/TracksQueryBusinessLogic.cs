using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public sealed class TracksQueryBusinessLogic : QueryBusinessLogicBase<Track>, ITracksQueryBusinessLogic
{
    #region Field Declarations

    private readonly string _selectByArtistIdStoredProcedure;
    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="pluralizer"></param>
    /// <param name="databaseService"></param>
    public TracksQueryBusinessLogic(ILogger<TracksQueryBusinessLogic> logger, IQueryDatabaseService databaseService)
        : base(logger, databaseService)
        => _selectByArtistIdStoredProcedure = $"[dbo].[{PluralModelName}_SelectByAlbumId]";

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumId"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Track>> SelectTracksAsync(int? albumId)
    {
        IEnumerable<Track> tracks;
        if (albumId.HasValue)
        {
            ModelParameter<Track> artistIdParameter = new(track => track.AlbumId, albumId);
            tracks = await SelectModelsAsync(_selectByArtistIdStoredProcedure, artistIdParameter).ConfigureAwait(false);
        }
        else
        {
            tracks = await SelectModelsAsync().ConfigureAwait(false);
        }
        return tracks;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Track?> SelectTrackAsync(int id)
    {
        ModelParameter<Track> parameter = new(track => track.TrackId, id);
        Track? selectedModel = await SelectModelAsync(parameter).ConfigureAwait(false);
        return selectedModel;
    }

    #endregion
}