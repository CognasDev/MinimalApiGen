using Samples.MusicCollection.Web.Models;

namespace Samples.MusicCollection.Web.AllMusic;

/// <summary>
/// 
/// </summary>
public sealed class AllMusicLogic : IAllMusicLogic
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public IRepository<Artist> ArtistsRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    public IRepository<Album> AlbumsRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    public IRepository<Genre> GenresRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    public IRepository<Key> KeysRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    public IRepository<Label> LabelsRepository { get; }

    /// <summary>
    /// 
    /// </summary>
    public IRepository<Track> TracksRepository { get; }

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="artistsRepository"></param>
    /// <param name="albumsRepository"></param>
    /// <param name="genresRepository"></param>
    /// <param name="keysRepository"></param>
    /// <param name="labelsRepository"></param>
    /// <param name="tracksRepository"></param>
    public AllMusicLogic(IRepository<Artist> artistsRepository,
                         IRepository<Album> albumsRepository,
                         IRepository<Genre> genresRepository,
                         IRepository<Key> keysRepository,
                         IRepository<Label> labelsRepository,
                         IRepository<Track> tracksRepository)
    {
        ArgumentNullException.ThrowIfNull(artistsRepository, nameof(artistsRepository));
        ArgumentNullException.ThrowIfNull(albumsRepository, nameof(albumsRepository));
        ArgumentNullException.ThrowIfNull(genresRepository, nameof(genresRepository));
        ArgumentNullException.ThrowIfNull(keysRepository, nameof(keysRepository));
        ArgumentNullException.ThrowIfNull(labelsRepository, nameof(labelsRepository));
        ArgumentNullException.ThrowIfNull(tracksRepository, nameof(tracksRepository));

        ArtistsRepository = artistsRepository;
        AlbumsRepository = albumsRepository;
        GenresRepository = genresRepository;
        KeysRepository = keysRepository;
        LabelsRepository = labelsRepository;
        TracksRepository = tracksRepository;
    }

    #endregion
}