using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Track = Samples.MusicCollection.Api.Tracks.Track;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class TrackCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapDeleteV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapDelete
        (
            "/tracks/{id}",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Tracks.ITracksCommandBusinessLogic businessLogic
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                await businessLogic.DeleteTrackAsync(id).ConfigureAwait(false);
                return TypedResults.NoContent();
            }
        )
        .WithName("Tracks-Delete-V1")
        .WithTags("tracks")
        .WithOpenApi(operation => new(operation) { Summary = "Deletes a Track via the id." })
        .MapToApiVersion(1)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}