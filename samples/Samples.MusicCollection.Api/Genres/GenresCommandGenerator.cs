using MinimalApiGen.Framework.Generation;
using Samples.MusicCollection.Api.Albums;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class GenresCommandGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public GenresCommandGenerator()
    {
        ApiGeneration.Command<Genre>().WithNamespaceOf<IGenresCommandHandler>()
                                      .WithModelId(model => model.GenreId)
                                      .WithPost()
                                            .WithHandler<IGenresCommandHandler>(command => command.InsertGenreAsync)
                                            .WithRequest<GenreRequest>()
                                            .WithFluentValidation()
                                            .WithRequestMappingService()
                                            .WithResponse<GenreResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Genre>().WithNamespaceOf<IGenresCommandHandler>()
                                      .WithModelId(model => model.GenreId)
                                      .WithPut()
                                          .WithHandler<IGenresCommandHandler>(command => command.UpdateGenreAsync)
                                          .WithRequest<GenreRequest>()
                                          .WithFluentValidation()
                                          .WithRequestMappingService()
                                          .WithResponse<GenreResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Genre>().WithNamespaceOf<IGenresCommandHandler>()
                                      .WithModelId(model => model.GenreId)
                                      .WithDelete()
                                            .WithHandler<IGenresCommandHandler>(command => command.DeleteGenreAsync)
                                            .WithRequest<GenreRequest>();

    }

    #endregion
}