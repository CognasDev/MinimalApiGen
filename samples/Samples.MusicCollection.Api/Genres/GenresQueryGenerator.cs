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
        ApiGeneration.Query<Genre>().WithNamespaceOf<IGenresQueryHandler>()
                                     .WithModelId(model => model.GenreId)
                                     .WithGet()
                                         .WithHandler<IGenresQueryHandler>(query => query.SelectGenresAsync)
                                         .WithResponse<GenreResponse>()
                                         .WithPagination()
                                         .WithMappingService()
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithHandler<IGenresQueryHandler>(query => query.SelectGenreAsync)
                                         .WithResponse<GenreResponse>()
                                         .WithMappingService()
                                         .WithVersion(1);

    }

    #endregion
}