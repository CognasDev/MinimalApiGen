using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Artist = Samples.MusicCollection.Api.Artists.Artist;
using ArtistRequest = Samples.MusicCollection.Api.Artists.ArtistRequest;
using ArtistResponse = Samples.MusicCollection.Api.Artists.ArtistResponse;

namespace Samples.MusicCollection.Api.Artists;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class ArtistCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapPutV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPut
        (
            "/artists/{id}",
            async Task<Results<Ok<ArtistResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromBody] ArtistRequest request,
				[FromServices] FluentValidation.IValidator<ArtistRequest> validator,
                [FromServices] Samples.MusicCollection.Api.Artists.IArtistsCommandBusinessLogic businessLogic,
                [FromServices] IMappingService<ArtistRequest, Artist> requestMappingService,
                [FromServices] IMappingService<Artist, ArtistResponse> responseMappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(validator, nameof(validator));
				ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(requestMappingService, nameof(requestMappingService));
                ArgumentNullException.ThrowIfNull(responseMappingService, nameof(responseMappingService));
                
				FluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request).ConfigureAwait(false);
				if (!validationResult.IsValid)
				{
					return TypedResults.ValidationProblem(validationResult.ToDictionary());
				}

                Artist model = requestMappingService.Map(request);

                if (model.ArtistId != id)
                {
                    return TypedResults.BadRequest();
                }

                Artist? updatedModel = await businessLogic.UpdateArtistAsync(model).ConfigureAwait(false);

                if (updatedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                ArtistResponse response = responseMappingService.Map(updatedModel);
                return TypedResults.Ok<ArtistResponse>(response);
            }
        )
        .WithName("Artists-Put-V1")
        .WithTags("artists")
        .WithOpenApi(operation => new(operation) { Summary = "Puts an Artist via an ArtistRequest, mapped to an ArtistResponse response." })
        .MapToApiVersion(1)
        .Accepts<ArtistRequest>(MediaTypeNames.Application.Json)
        .Produces<ArtistResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}