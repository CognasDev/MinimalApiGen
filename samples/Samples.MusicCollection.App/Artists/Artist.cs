namespace Samples.MusicCollection.App.Artists;

/// <summary>
/// 
/// </summary>
public sealed record Artist
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required int ArtistId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Name { get; set; }

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="Artist"/>
    /// </summary>
    public Artist()
    {
    }

    #endregion
}