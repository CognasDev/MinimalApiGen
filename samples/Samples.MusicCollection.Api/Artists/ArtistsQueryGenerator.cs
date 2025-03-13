using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class ArtistsQueryGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public ArtistsQueryGenerator()
    {
        ApiGeneration.Query<Artist>().WithNamespaceOf<IArtistsQueryHandler>()
                                     .WithModelId(model => model.ArtistId)
                                     .WithGet()
                                         .WithHandler<IArtistsQueryHandler>(query => query.SelectArtistsAsync)
                                         .WithResponse<ArtistResponse>()
                                         .WithPagination()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithHandler<IArtistsQueryHandler>(query => query.SelectArtistAsync)
                                         .WithResponse<ArtistResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}