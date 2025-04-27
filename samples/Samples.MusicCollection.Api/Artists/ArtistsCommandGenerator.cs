using MinimalApiGen.Framework.Generation;
using Samples.MusicCollection.Api.Albums;

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
        ApiGeneration.Command<Artist>().WithNamespaceOf<IArtistsCommandHandler>()
                                       .WithModelId(model => model.ArtistId)
                                       .WithPost()
                                            .WithHandler<IArtistsCommandHandler>(command => command.InsertArtistAsync)
                                            .WithJwtAuthentication()
                                            .WithRequest<ArtistRequest>()
                                            .WithFluentValidation()
                                            .WithRequestMappingService()
                                            .WithResponse<ArtistResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Artist>().WithNamespaceOf<IArtistsCommandHandler>()
                                       .WithModelId(model => model.ArtistId)
                                       .WithPut()
                                           .WithHandler<IArtistsCommandHandler>(command => command.UpdateArtistAsync)
                                           .WithRequest<ArtistRequest>()
                                           .WithFluentValidation()
                                           .WithRequestMappingService()
                                           .WithResponse<ArtistResponse>()
                                           .WithResponseMappingService();

        ApiGeneration.Command<Artist>().WithNamespaceOf<IArtistsCommandHandler>()
                                       .WithModelId(model => model.ArtistId)
                                       .WithDelete()
                                            .WithHandler<IArtistsCommandHandler>(command => command.DeleteArtistAsync)
                                            .WithRequest<ArtistRequest>();

    }

    #endregion
}