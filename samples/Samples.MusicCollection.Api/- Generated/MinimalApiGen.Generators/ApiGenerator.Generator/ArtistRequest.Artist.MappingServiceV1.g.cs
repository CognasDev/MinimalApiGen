using MinimalApiGen.Framework.Mapping;
using Artist = Samples.MusicCollection.Api.Artists.Artist;
using ArtistRequest = Samples.MusicCollection.Api.Artists.ArtistRequest;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed class PostArtistRequestToArtistMappingServiceV1 : MappingServiceBase<ArtistRequest, Artist>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public override Artist Map(ArtistRequest request)
    {
        Artist model = new()
        {
			ArtistId = request.ArtistId,
			Name = request.Name
        };
        return model;
    }

    #endregion
}