﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Genre = Samples.MusicCollection.Api.Genres.Genre;
using GenreRequest = Samples.MusicCollection.Api.Genres.GenreRequest;
using GenreResponse = Samples.MusicCollection.Api.Genres.GenreResponse;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class GenreCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapPutV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPut
        (
            "/genres/{id}",
            async Task<Results<Ok<GenreResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromBody] GenreRequest request,
				[FromServices] FluentValidation.IValidator<GenreRequest> validator,
                [FromServices] Samples.MusicCollection.Api.Genres.IGenresCommandHandler handler,
                [FromServices] IMappingService<GenreRequest, Genre> requestMappingService,
                [FromServices] IMappingService<Genre, GenreResponse> responseMappingService
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

                Genre model = requestMappingService.Map(request);

                if (model.GenreId != id)
                {
                    return TypedResults.BadRequest();
                }

                Genre? updatedModel = await handler.UpdateGenreAsync(model).ConfigureAwait(false);

                if (updatedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                GenreResponse response = responseMappingService.Map(updatedModel);
                return TypedResults.Ok<GenreResponse>(response);
            }
        )
        .WithName("Genres-Put-V1")
        .WithTags("genres")
        .WithOpenApi(operation => new(operation) { Summary = "Puts a Genre via a GenreRequest, mapped to a GenreResponse response." })
        .MapToApiVersion(1)
        .Accepts<GenreRequest>(MediaTypeNames.Application.Json)
        .Produces<GenreResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}