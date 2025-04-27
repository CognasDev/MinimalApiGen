using MinimalApiGen.Framework.ApiHandlers;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class ArtistsCommandHandler(ILogger<ArtistsCommandHandler> logger, ICommandDatabaseService databaseService)
    : CommandHandlerBase<Artist>(logger, databaseService), IArtistsCommandHandler
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Artist> InsertArtistAsync(Artist album) => await InsertModelAsync(album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Artist> UpdateArtistAsync(Artist album) => await UpdateModelAsync(album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteArtistAsync(int id)
    {
        ModelParameter<Artist> parameter = new(artist => artist.ArtistId, id);
        await DeleteModelAsync(parameter);
    }

    #endregion
}