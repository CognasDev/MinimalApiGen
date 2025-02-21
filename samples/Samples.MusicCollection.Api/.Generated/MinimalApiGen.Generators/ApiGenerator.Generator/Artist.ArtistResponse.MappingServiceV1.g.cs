using MinimalApiGen.Framework.Mapping;
using Artist = Samples.MusicCollection.Api.Artists.Artist;
using ArtistResponse = Samples.MusicCollection.Api.Artists.ArtistResponse;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
public sealed class GetArtistToArtistResponseMappingServiceV1 : MappingServiceBase<Artist, ArtistResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override ArtistResponse Map(Artist model)
    {
        ArtistResponse response = new()
        {
			ArtistId = model.ArtistId,
			Name = model.Name,

        };
        return response;
    }

    #endregion
}