﻿namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
public interface IGenresQueryHandler
{
    #region Method Declarations

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