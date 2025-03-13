namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public interface ITracksCommandHandler
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Track> InsertTrackAsync(Track album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Track> UpdateTrackAsync(Track album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteTrackAsync(int id);

    #endregion
}