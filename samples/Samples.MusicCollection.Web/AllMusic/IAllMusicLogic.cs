using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public interface IAllMusicLogic
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    IRepository<Artist> ArtistsRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    IRepository<Album> AlbumsRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    IRepository<Genre> GenresRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    IRepository<Key> KeysRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    IRepository<Label> LabelsRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    IRepository<Track> TracksRepository { get; }

    #endregion
}