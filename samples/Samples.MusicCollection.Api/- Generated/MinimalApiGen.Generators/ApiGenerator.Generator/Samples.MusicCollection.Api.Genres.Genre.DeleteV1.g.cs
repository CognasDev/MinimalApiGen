using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Genre = Samples.MusicCollection.Api.Genres.Genre;
using GenreRequest = Samples.MusicCollection.Api.Genres.GenreRequest;
namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class GenreCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapDeleteV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapDelete
        (
            "/genres/{id}",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromBody] GenreRequest request,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Genres.IGenresCommandHandler handler
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(request, nameof(request));
                await handler.DeleteGenreAsync(id).ConfigureAwait(false);
                return TypedResults.NoContent();
            }
        )
        .WithName("Genres-Delete-V1")
        .WithTags("genres")
        .WithOpenApi(operation => new(operation) { Summary = "Deletes a Genre via the id." })
        .MapToApiVersion(1)
        .Accepts<GenreRequest>(MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}