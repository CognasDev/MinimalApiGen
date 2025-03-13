using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class ArtistsQueryHandler(ILogger<ArtistsQueryHandler> logger, IQueryDatabaseService databaseService)
    : QueryHandlerBase<Artist>(logger, databaseService), IArtistsQueryHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Artist>> SelectArtistsAsync() => await SelectModelsAsync().ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Artist?> SelectArtistAsync(int id)
    {
        ModelParameter<Artist> parameter = new(artist => artist.ArtistId, id);
        Artist? artist = await SelectModelAsync(parameter).ConfigureAwait(false);
        return artist;
    }

    #endregion
}