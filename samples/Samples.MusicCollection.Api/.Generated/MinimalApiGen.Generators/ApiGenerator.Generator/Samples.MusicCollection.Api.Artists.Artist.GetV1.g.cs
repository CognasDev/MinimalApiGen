using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
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
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/artists",
            (
                CancellationToken cancellationToken,
                [FromServices] Samples.MusicCollection.Api.Artists.IArtistsQueryBusinessLogic businessLogic,
                [FromServices] IMappingService<Artist, ArtistResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<ArtistResponse> ArtistResponseStreamAsync()
                {
                    IEnumerable<Artist> models = await businessLogic.SelectArtistsAsync().ConfigureAwait(false);
                    IEnumerable<ArtistResponse> responses = mappingService.Map(models);

                    foreach (ArtistResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return ArtistResponseStreamAsync();   
            }
        )
        .WithName("Artists-Get-V1")
        .WithTags("artists")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of Artists mapped to ArtistResponse responses." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<ArtistResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}