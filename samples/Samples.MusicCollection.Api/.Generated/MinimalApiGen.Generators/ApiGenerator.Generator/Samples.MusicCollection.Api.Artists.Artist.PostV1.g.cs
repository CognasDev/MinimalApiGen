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
    public virtual RouteHandlerBuilder MapPostV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPost
        (
            "/artists",
            async Task<Results<CreatedAtRoute<ArtistResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
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
                Artist? insertedModel = await businessLogic.InsertArtistAsync(model).ConfigureAwait(false);

                if (insertedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                ArtistResponse response = responseMappingService.Map(insertedModel);
                string routeName = "Artists-GetById-V1";
                int? newId = insertedModel.ArtistId ?? throw new NullReferenceException();
                return TypedResults.CreatedAtRoute<ArtistResponse>(response, routeName, new {id = newId});
            }
        )
        .WithName("Artists-Post-V1")
        .WithTags("artists")
        .WithOpenApi(operation => new(operation) { Summary = "Posts an Artist via an ArtistRequest, mapped to an ArtistResponse response." })
        .MapToApiVersion(1)
        .Accepts<ArtistRequest>(MediaTypeNames.Application.Json)
        .Produces<ArtistResponse>(StatusCodes.Status201Created, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}