using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record AlbumDetail
{
    #region Field Declarations

    private List<TrackDetail>? _tracks;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? AlbumId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Genre? Genre { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public Label? Label { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required DateTime ReleaseDate { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<TrackDetail> Tracks => _tracks ?? [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tracks"></param>
    public void AddTracks(IEnumerable<TrackDetail> tracks)
    {
        _tracks = [.. tracks];
    }

    #endregion
}