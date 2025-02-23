using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class AlbumsCommandGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public AlbumsCommandGenerator()
    {
        ApiGeneration.Command<Album>().WithNamespaceOf<IAlbumsCommandBusinessLogic>()
                                      .WithModelId(model => model.AlbumId)
                                      .WithPost()
                                            .WithBusinessLogic<IAlbumsCommandBusinessLogic>(command => command.InsertAlbumAsync)
                                            .WithRequest<AlbumRequest>()
                                            .WithFluentValidation()
                                            .WithRequestMappingService()
                                            .WithResponse<AlbumResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Album>().WithNamespaceOf<IAlbumsCommandBusinessLogic>()
                                      .WithModelId(model => model.AlbumId)
                                      .WithPut()
                                          .WithBusinessLogic<IAlbumsCommandBusinessLogic>(command => command.UpdateAlbumAsync)
                                          .WithRequest<AlbumRequest>()
                                          .WithFluentValidation()
                                          .WithRequestMappingService()
                                          .WithResponse<AlbumResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Album>().WithNamespaceOf<IAlbumsCommandBusinessLogic>()
                                      .WithModelId(model => model.AlbumId)
                                      .WithDelete()
                                            .WithBusinessLogic<IAlbumsCommandBusinessLogic>(command => command.DeleteAlbumAsync);

    }

    #endregion
}