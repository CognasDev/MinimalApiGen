using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Artist = Samples.MusicCollection.Api.Artists.Artist;
using ArtistResponse = Samples.MusicCollection.Api.Artists.ArtistResponse;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class ArtistQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/artists/{id}",
            async Task<Results<Ok<ArtistResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Artists.IArtistsQueryHandler handler,
                [FromServices] IMappingService<Artist, ArtistResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                Artist? model = await handler.SelectArtistAsync(id).ConfigureAwait(false);

                if (model is null)
                {
                    return TypedResults.NotFound();
                }

                ArtistResponse response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }
        )
        .WithName("Artists-GetById-V1")
        .WithTags("artists")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of an Artist by the id, mapped to an ArtistResponse response." })
        .MapToApiVersion(1)
        .Produces<ArtistResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}