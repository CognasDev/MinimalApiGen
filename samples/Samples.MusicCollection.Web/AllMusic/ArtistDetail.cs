using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record ArtistDetail
{
    #region Field Declarations

    private readonly ConcurrentBag<AlbumDetail> _albums = [];

    #endregion

    #region Property Declarations

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
    public IEnumerable<AlbumDetail> Albums => _albums;

    /// <summary>
    /// 
    /// </summary>
    public bool HasAlbums => !_albums.IsEmpty;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public void ClearAlbums() => _albums.Clear();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="album"></param>
    public void AddAlbum(AlbumDetail album) => _albums.Add(album);

    #endregion
}