namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public interface ITracksQueryHandler
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="albumId"></param>
    /// <returns></returns>
    Task<IEnumerable<Track>> SelectTracksAsync(int? albumId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Track?> SelectTrackAsync(int id);

    #endregion
}