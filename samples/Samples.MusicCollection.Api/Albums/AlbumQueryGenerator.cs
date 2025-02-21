using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Albums;
/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class AlbumQueryGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public AlbumQueryGenerator()
    {
        ApiGeneration.Query<Album>().WithNamespaceOf<IAlbumQueryBusinessLogic>()
                                    .WithModelId(model => model.AlbumId)
                                    .WithGet()
                                        .WithBusinessLogic<IAlbumQueryBusinessLogic>(query => query.SelectAlbumsAsync)
                                        .WithResponse<AlbumResponse>()
                                        .WithMappingService()
                                        .WithVersion(1)
                                    .WithGetById()
                                         .WithBusinessLogic<IAlbumQueryBusinessLogic>(query => query.SelectAlbumAsync)
                                         .WithResponse<AlbumResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}