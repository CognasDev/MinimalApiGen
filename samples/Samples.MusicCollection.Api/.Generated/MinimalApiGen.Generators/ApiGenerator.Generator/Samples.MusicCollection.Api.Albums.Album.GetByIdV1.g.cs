using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Album = Samples.MusicCollection.Api.Albums.Album;
using AlbumResponse = Samples.MusicCollection.Api.Albums.AlbumResponse;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class AlbumQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/albums/{id}",
            async Task<Results<Ok<AlbumResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Albums.IAlbumsQueryBusinessLogic businessLogic,
                [FromServices] IMappingService<Album, AlbumResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                Album? model = await businessLogic.SelectAlbumAsync(id).ConfigureAwait(false);

                if (model is null)
                {
                    return TypedResults.NotFound();
                }

                AlbumResponse response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }
        )
        .WithName("Albums-GetById-V1")
        .WithTags("albums")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of an Album by the id, mapped to an AlbumResponse response." })
        .MapToApiVersion(1)
        .Produces<AlbumResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}