using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record AlbumDetail
{
    #region Field Declarations

    private readonly ConcurrentBag<TrackDetail> _tracks = [];

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? AlbumId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? ArtistId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? GenreId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? LabelId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTime? ReleaseDate { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<TrackDetail> Tracks => _tracks;

    /// <summary>
    /// 
    /// </summary>
    public bool HasTracks => !_tracks.IsEmpty;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public void ClearTracks() => _tracks.Clear();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="track"></param>
    public void AddTrack(TrackDetail track) => _tracks.Add(track);

    #endregion
}