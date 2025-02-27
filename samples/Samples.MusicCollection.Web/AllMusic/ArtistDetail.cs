using Samples.MusicCollection.Web.Models;
using System.Collections.Concurrent;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record ArtistDetail
{
    #region Field Declarations

    private readonly ConcurrentBag<Album> _albums = [];

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public int? ArtistId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<Album> Albums => _albums;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="album"></param>
    public void AddAlbum(Album album)
    {
        _albums.Add(album);
    }

    #endregion
}