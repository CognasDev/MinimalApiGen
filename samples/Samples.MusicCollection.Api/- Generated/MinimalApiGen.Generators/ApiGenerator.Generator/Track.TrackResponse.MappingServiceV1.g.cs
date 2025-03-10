using MinimalApiGen.Framework.Mapping;
using Track = Samples.MusicCollection.Api.Tracks.Track;
using TrackResponse = Samples.MusicCollection.Api.Tracks.TrackResponse;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public sealed class PostTrackToTrackResponseMappingServiceV1 : MappingServiceBase<Track, TrackResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override TrackResponse Map(Track model)
    {
        TrackResponse response = new()
        {
			TrackId = model.TrackId,
			AlbumId = model.AlbumId,
			GenreId = model.GenreId,
			KeyId = model.KeyId,
			TrackNumber = model.TrackNumber,
			Name = model.Name,
			Bpm = model.Bpm
        };
        return response;
    }

    #endregion
}