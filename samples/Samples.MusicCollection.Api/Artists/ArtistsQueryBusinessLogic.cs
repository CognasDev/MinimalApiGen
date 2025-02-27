using MinimalApiGen.Framework.BusinessLogic;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Pluralize;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
/// <param name="logger"></param>
/// <param name="pluralizer"></param>
/// <param name="databaseService"></param>
public sealed class ArtistsQueryBusinessLogic(ILogger<ArtistsQueryBusinessLogic> logger, IPluralizer pluralizer, IQueryDatabaseService databaseService)
    : QueryBusinessLogicBase<Artist>(logger, pluralizer, databaseService), IArtistsQueryBusinessLogic
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