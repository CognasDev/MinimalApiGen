using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Album = Samples.MusicCollection.Api.Albums.Album;

namespace Samples.MusicCollection.Api.Albums;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class AlbumCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapDeleteV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapDelete
        (
            "/albums/{id}",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Albums.IAlbumsCommandBusinessLogic businessLogic
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                await businessLogic.DeleteAlbumAsync(id).ConfigureAwait(false);
                return TypedResults.NoContent();
            }
        )
        .WithName("Albums-Delete-V1")
        .WithTags("albums")
        .WithOpenApi(operation => new(operation) { Summary = "Deletes an Album via the id." })
        .MapToApiVersion(1)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}