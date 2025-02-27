using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
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
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/tracks",
            (
                CancellationToken cancellationToken,
				[FromQuery] int? albumId,
                [FromServices] Samples.MusicCollection.Api.Tracks.ITracksQueryBusinessLogic businessLogic,
                [FromServices] IMappingService<Track, TrackResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<TrackResponse> TrackResponseStreamAsync()
                {
                    IEnumerable<Track> models = await businessLogic.SelectTracksAsync(albumId).ConfigureAwait(false);
                    IEnumerable<TrackResponse> responses = mappingService.Map(models);

                    foreach (TrackResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return TrackResponseStreamAsync();   
            }
        )
        .WithName("Tracks-Get-V1")
        .WithTags("tracks")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of Tracks mapped to TrackResponse responses." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<TrackResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}