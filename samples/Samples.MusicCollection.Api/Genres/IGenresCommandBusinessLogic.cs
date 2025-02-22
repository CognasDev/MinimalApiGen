namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public interface IGenresCommandBusinessLogic
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Genre> InsertGenreAsync(Genre album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Genre> UpdateGenreAsync(Genre album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteGenreAsync(int id);

    #endregion
}