using MinimalApiGen.Framework.Generation;

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
        ApiGeneration.Command<Genre>().WithNamespaceOf<IGenresCommandBusinessLogic>()
                                      .WithModelId(model => model.GenreId)
                                      .WithPost()
                                            .WithBusinessLogic<IGenresCommandBusinessLogic>(command => command.InsertGenreAsync)
                                            .WithRequest<GenreRequest>()
                                            .WithRequestMappingService()
                                            .WithResponse<GenreResponse>()
                                            .WithResponseMappingService();

        ApiGeneration.Command<Genre>().WithNamespaceOf<IGenresCommandBusinessLogic>()
                                      .WithModelId(model => model.GenreId)
                                      .WithPut()
                                          .WithBusinessLogic<IGenresCommandBusinessLogic>(command => command.UpdateGenreAsync)
                                          .WithRequest<GenreRequest>()
                                          .WithRequestMappingService()
                                          .WithResponse<GenreResponse>()
                                          .WithResponseMappingService();

        ApiGeneration.Command<Genre>().WithNamespaceOf<IGenresCommandBusinessLogic>()
                                      .WithModelId(model => model.GenreId)
                                      .WithDelete()
                                            .WithBusinessLogic<IGenresCommandBusinessLogic>(command => command.DeleteGenreAsync);

    }

    #endregion
}