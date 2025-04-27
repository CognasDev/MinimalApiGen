using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
public sealed class AlbumsQueryHandler : QueryHandlerBase<Album>, IAlbumsQueryHandler
{
    #region Field Declarations

    private readonly string _selectByArtistIdStoredProcedure;
    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="databaseService"></param>
    public AlbumsQueryHandler(ILogger<AlbumsQueryHandler> logger, IQueryDatabaseService databaseService)
        : base(logger, databaseService)
        => _selectByArtistIdStoredProcedure = $"[dbo].[{PluralModelName}_SelectByArtistId]";

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistId"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Album>> SelectAlbumsAsync(int? artistId)
    {
        IEnumerable<Album> albums;
        if (artistId.HasValue)
        {
            ModelParameter<Album> artistIdParameter = new(album => album.ArtistId, artistId);
            albums = await SelectModelsAsync(_selectByArtistIdStoredProcedure, artistIdParameter);
        }
        else
        {
            albums = await SelectModelsAsync();
        }
        return albums;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Album?> SelectAlbumAsync(int id)
    {
        ModelParameter<Album> parameter = new(album => album.AlbumId, id);
        Album? album = await SelectModelAsync(parameter);
        return album;
    }

    #endregion
}