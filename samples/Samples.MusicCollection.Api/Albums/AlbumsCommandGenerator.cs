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
        ApiGeneration.Command<Album>().WithNamespaceOf<IAlbumsCommandHandler>()
                                      .WithModelId(model => model.AlbumId)
                                      .WithPost()
                                            .WithHandler<IAlbumsCommandHandler>(command => command.InsertAlbumAsync)
                                            .WithRequest<AlbumRequest>()
                                            .WithFluentValidation()
                                            .WithRequestMappingService()
                                            .WithResponse<AlbumResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Album>().WithNamespaceOf<IAlbumsCommandHandler>()
                                      .WithModelId(model => model.AlbumId)
                                      .WithPut()
                                          .WithHandler<IAlbumsCommandHandler>(command => command.UpdateAlbumAsync)
                                          .WithRequest<AlbumRequest>()
                                          .WithFluentValidation()
                                          .WithRequestMappingService()
                                          .WithResponse<AlbumResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Album>().WithNamespaceOf<IAlbumsCommandHandler>()
                                      .WithModelId(model => model.AlbumId)
                                      .WithDelete()
                                            .WithHandler<IAlbumsCommandHandler>(command => command.DeleteAlbumAsync);

    }

    #endregion
}