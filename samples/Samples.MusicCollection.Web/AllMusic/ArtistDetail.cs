namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed record ArtistDetail
{
    #region Field Declarations

    private List<AlbumDetail>? _albums;

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
    public IEnumerable<AlbumDetail> Albums => _albums ?? [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="album"></param>
    public void AddAlbums(IEnumerable<AlbumDetail> albums)
    {
        _albums = [.. albums];
    }

    #endregion
}