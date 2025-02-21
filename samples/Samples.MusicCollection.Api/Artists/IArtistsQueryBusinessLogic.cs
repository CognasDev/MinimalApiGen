using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public interface IArtistsQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Artist>> SelectArtistsAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Artist?> SelectArtistAsync(int id);

    #endregion
}