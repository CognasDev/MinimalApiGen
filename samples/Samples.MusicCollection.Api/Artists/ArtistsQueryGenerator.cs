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
        ApiGeneration.Query<Artist>().WithNamespaceOf<IArtistsQueryBusinessLogic>()
                                     .WithModelId(model => model.ArtistId)
                                     .WithGet()
                                         .WithBusinessLogic<IArtistsQueryBusinessLogic>(query => query.SelectArtistsAsync)
                                         .WithResponse<ArtistResponse>()
                                         .WithPagination()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithBusinessLogic<IArtistsQueryBusinessLogic>(query => query.SelectArtistAsync)
                                         .WithResponse<ArtistResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}