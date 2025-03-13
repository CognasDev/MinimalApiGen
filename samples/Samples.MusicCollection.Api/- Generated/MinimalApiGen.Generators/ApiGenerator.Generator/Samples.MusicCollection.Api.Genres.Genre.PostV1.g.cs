using Microsoft.AspNetCore.Http.HttpResults;
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
    public virtual RouteHandlerBuilder MapPostV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPost
        (
            "/genres",
            async Task<Results<CreatedAtRoute<GenreResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
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
                Genre? insertedModel = await handler.InsertGenreAsync(model).ConfigureAwait(false);

                if (insertedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                GenreResponse response = responseMappingService.Map(insertedModel);
                string routeName = "Genres-GetById-V1";
                int? newId = insertedModel.GenreId ?? throw new NullReferenceException();
                return TypedResults.CreatedAtRoute<GenreResponse>(response, routeName, new {id = newId});
            }
        )
        .WithName("Genres-Post-V1")
        .WithTags("genres")
        .WithOpenApi(operation => new(operation) { Summary = "Posts a Genre via a GenreRequest, mapped to a GenreResponse response." })
        .MapToApiVersion(1)
        .Accepts<GenreRequest>(MediaTypeNames.Application.Json)
        .Produces<GenreResponse>(StatusCodes.Status201Created, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}