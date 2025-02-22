using MinimalApiGen.Framework.Mapping;
using Track = Samples.MusicCollection.Api.Tracks.Track;
using TrackRequest = Samples.MusicCollection.Api.Tracks.TrackRequest;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
public sealed class PostTrackRequestToTrackMappingServiceV1 : MappingServiceBase<TrackRequest, Track>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public override Track Map(TrackRequest request)
    {
        Track model = new()
        {
			TrackId = request.TrackId,
			AlbumId = request.AlbumId,
			GenreId = request.GenreId,
			KeyId = request.KeyId,
			TrackNumber = request.TrackNumber,
			Name = request.Name,
			Bpm = request.Bpm,

        };
        return model;
    }

    #endregion
}