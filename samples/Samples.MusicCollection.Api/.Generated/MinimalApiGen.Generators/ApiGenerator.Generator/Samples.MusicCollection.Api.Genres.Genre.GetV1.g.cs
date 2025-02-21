﻿using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using Genre = Samples.MusicCollection.Api.Genres.Genre;
using GenreResponse = Samples.MusicCollection.Api.Genres.GenreResponse;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class GenreQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/genres",
            (
                CancellationToken cancellationToken,
                [FromServices] Samples.MusicCollection.Api.Genres.IGenresQueryBusinessLogic businessLogic,
                [FromServices] IMappingService<Genre, GenreResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<GenreResponse> GenreResponseStreamAsync()
                {
                    IEnumerable<Genre> models = await businessLogic.SelectGenresAsync().ConfigureAwait(false);
                    IEnumerable<GenreResponse> responses = mappingService.Map(models);

                    foreach (GenreResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return GenreResponseStreamAsync();   
            }
        )
        .WithName("Genres-Get-V1")
        .WithTags("genres")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of Genres mapped to GenreResponse responses." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<GenreResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}