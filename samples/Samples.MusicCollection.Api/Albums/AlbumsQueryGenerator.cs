using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class AlbumsQueryGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public AlbumsQueryGenerator()
    {
        ApiGeneration.Query<Album>().WithNamespaceOf<IAlbumsQueryHandler>()
                                    .WithModelId(model => model.AlbumId)
                                    .WithGet()
                                        .WithHandler<IAlbumsQueryHandler>(query => query.SelectAlbumsAsync)
                                        .WithQueryParameters<Album>(model => model.ArtistId)
                                        .WithResponse<AlbumResponse>()
                                        .WithPagination()
                                        .WithMappingService()
                                        .WithVersion(1)
                                    .WithGetById()
                                         .WithHandler<IAlbumsQueryHandler>(query => query.SelectAlbumAsync)
                                         .WithResponse<AlbumResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}