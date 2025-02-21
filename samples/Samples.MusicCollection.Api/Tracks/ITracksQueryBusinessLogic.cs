using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public interface ITracksQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Track>> SelectTracksAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Track?> SelectTrackAsync(int id);

    #endregion
}