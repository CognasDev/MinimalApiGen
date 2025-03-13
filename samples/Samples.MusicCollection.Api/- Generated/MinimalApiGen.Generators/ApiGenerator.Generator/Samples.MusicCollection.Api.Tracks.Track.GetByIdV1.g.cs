using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Track = Samples.MusicCollection.Api.Tracks.Track;
using TrackResponse = Samples.MusicCollection.Api.Tracks.TrackResponse;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class TrackQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/tracks/{id}",
            async Task<Results<Ok<TrackResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Tracks.ITracksQueryHandler handler,
                [FromServices] IMappingService<Track, TrackResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                Track? model = await handler.SelectTrackAsync(id).ConfigureAwait(false);

                if (model is null)
                {
                    return TypedResults.NotFound();
                }

                TrackResponse response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }
        )
        .WithName("Tracks-GetById-V1")
        .WithTags("tracks")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of a Track by the id, mapped to a TrackResponse response." })
        .MapToApiVersion(1)
        .Produces<TrackResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}