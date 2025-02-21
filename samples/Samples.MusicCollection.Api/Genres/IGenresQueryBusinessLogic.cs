using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public interface IGenresQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Genre>> SelectGenresAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Genre?> SelectGenreAsync(int id);

    #endregion
}