using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Genre = Samples.MusicCollection.Api.Genres.Genre;
using GenreResponse = Samples.MusicCollection.Api.Genres.GenreResponse;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class GenreQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/genres/{id}",
            async Task<Results<Ok<GenreResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Genres.IGenresQueryHandler handler,
                [FromServices] IMappingService<Genre, GenreResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                Genre? model = await handler.SelectGenreAsync(id).ConfigureAwait(false);

                if (model is null)
                {
                    return TypedResults.NotFound();
                }

                GenreResponse response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }
        )
        .WithName("Genres-GetById-V1")
        .WithTags("genres")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of a Genre by the id, mapped to a GenreResponse response." })
        .MapToApiVersion(1)
        .Produces<GenreResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}