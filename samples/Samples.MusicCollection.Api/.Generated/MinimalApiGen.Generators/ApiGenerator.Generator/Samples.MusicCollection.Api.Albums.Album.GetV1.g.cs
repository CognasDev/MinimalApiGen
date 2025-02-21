﻿using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
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
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/albums",
            (
                CancellationToken cancellationToken,
                [FromServices] Samples.MusicCollection.Api.Albums.IAlbumQueryBusinessLogic businessLogic,
                [FromServices] IMappingService<Album, AlbumResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<AlbumResponse> AlbumResponseStreamAsync()
                {
                    IEnumerable<Album> models = await businessLogic.SelectAlbumsAsync().ConfigureAwait(false);
                    IEnumerable<AlbumResponse> responses = mappingService.Map(models);

                    foreach (AlbumResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return AlbumResponseStreamAsync();   
            }
        )
        .WithName("Albums-Get-V1")
        .WithTags("albums")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of Albums mapped to AlbumResponse responses." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<AlbumResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}