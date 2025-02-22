using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class ArtistsCommandGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public ArtistsCommandGenerator()
    {
        ApiGeneration.Command<Artist>().WithNamespaceOf<IArtistsCommandBusinessLogic>()
                                      .WithModelId(model => model.ArtistId)
                                      .WithPost()
                                            .WithBusinessLogic<IArtistsCommandBusinessLogic>(command => command.InsertArtistAsync)
                                            .WithRequest<ArtistRequest>()
                                            .WithRequestMappingService()
                                            .WithResponse<ArtistResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Artist>().WithNamespaceOf<IArtistsCommandBusinessLogic>()
                                      .WithModelId(model => model.ArtistId)
                                      .WithPut()
                                          .WithBusinessLogic<IArtistsCommandBusinessLogic>(command => command.UpdateArtistAsync)
                                          .WithRequest<ArtistRequest>()
                                          .WithRequestMappingService()
                                          .WithResponse<ArtistResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Artist>().WithNamespaceOf<IArtistsCommandBusinessLogic>()
                                      .WithModelId(model => model.ArtistId)
                                      .WithDelete()
                                            .WithBusinessLogic<IArtistsCommandBusinessLogic>(command => command.DeleteArtistAsync);

    }

    #endregion
}