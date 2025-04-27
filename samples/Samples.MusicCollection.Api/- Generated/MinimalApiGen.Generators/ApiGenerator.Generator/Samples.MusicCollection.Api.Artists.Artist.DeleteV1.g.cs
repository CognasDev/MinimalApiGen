using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Artist = Samples.MusicCollection.Api.Artists.Artist;
using ArtistRequest = Samples.MusicCollection.Api.Artists.ArtistRequest;
namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class ArtistCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapDeleteV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapDelete
        (
            "/artists/{id}",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromBody] ArtistRequest request,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Artists.IArtistsCommandHandler handler
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(request, nameof(request));
                await handler.DeleteArtistAsync(id).ConfigureAwait(false);
                return TypedResults.NoContent();
            }
        )
        .WithName("Artists-Delete-V1")
        .WithTags("artists")
        .WithOpenApi(operation => new(operation) { Summary = "Deletes an Artist via the id." })
        .MapToApiVersion(1)
        .Accepts<ArtistRequest>(MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}