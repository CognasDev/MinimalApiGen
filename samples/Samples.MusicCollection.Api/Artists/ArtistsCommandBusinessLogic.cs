using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="databaseService"></param>
public sealed class ArtistsCommandBusinessLogic(ILogger<ArtistsCommandBusinessLogic> logger, ICommandDatabaseService databaseService)
    : CommandBusinessLogicBase<Artist>(logger, databaseService), IArtistsCommandBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Artist> InsertArtistAsync(Artist album) => await InsertModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Artist> UpdateArtistAsync(Artist album) => await UpdateModelAsync(album).ConfigureAwait(false);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task DeleteArtistAsync(int id)
    {
        ModelParameter<Artist> parameter = new(artist => artist.ArtistId, id);
        await DeleteModelAsync(parameter).ConfigureAwait(false);
    }

    #endregion
}