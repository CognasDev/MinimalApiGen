using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class GenresQueryGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public GenresQueryGenerator()
    {
        ApiGeneration.Query<Genre>().WithNamespaceOf<IGenresQueryBusinessLogic>()
                                     .WithModelId(model => model.GenreId)
                                     .WithGet()
                                         .WithBusinessLogic<IGenresQueryBusinessLogic>(query => query.SelectGenresAsync)
                                         .WithResponse<GenreResponse>()
                                         .WithPagination()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithBusinessLogic<IGenresQueryBusinessLogic>(query => query.SelectGenreAsync)
                                         .WithResponse<GenreResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}