﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Album = Samples.MusicCollection.Api.Albums.Album;
using AlbumRequest = Samples.MusicCollection.Api.Albums.AlbumRequest;
using AlbumResponse = Samples.MusicCollection.Api.Albums.AlbumResponse;

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
    public virtual RouteHandlerBuilder MapPutV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPut
        (
            "/albums/{id}",
            async Task<Results<Ok<AlbumResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromBody] AlbumRequest request,
				[FromServices] FluentValidation.IValidator<AlbumRequest> validator,
                [FromServices] Samples.MusicCollection.Api.Albums.IAlbumsCommandHandler handler,
                [FromServices] IMappingService<AlbumRequest, Album> requestMappingService,
                [FromServices] IMappingService<Album, AlbumResponse> responseMappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(validator, nameof(validator));
				ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(requestMappingService, nameof(requestMappingService));
                ArgumentNullException.ThrowIfNull(responseMappingService, nameof(responseMappingService));
                
				FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request).ConfigureAwait(false);
				if (!validationResult.IsValid)
				{
					return TypedResults.ValidationProblem(validationResult.ToDictionary());
				}

                Album model = requestMappingService.Map(request);

                if (model.AlbumId != id)
                {
                    return TypedResults.BadRequest();
                }

                Album? updatedModel = await handler.UpdateAlbumAsync(model).ConfigureAwait(false);

                if (updatedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                AlbumResponse response = responseMappingService.Map(updatedModel);
                return TypedResults.Ok<AlbumResponse>(response);
            }
        )
        .WithName("Albums-Put-V1")
        .WithTags("albums")
        .WithOpenApi(operation => new(operation) { Summary = "Puts an Album via an AlbumRequest, mapped to an AlbumResponse response." })
        .MapToApiVersion(1)
        .Accepts<AlbumRequest>(MediaTypeNames.Application.Json)
        .Produces<AlbumResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}