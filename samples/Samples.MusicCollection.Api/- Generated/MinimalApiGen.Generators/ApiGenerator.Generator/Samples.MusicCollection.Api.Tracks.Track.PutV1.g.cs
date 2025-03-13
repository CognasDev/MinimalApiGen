using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Track = Samples.MusicCollection.Api.Tracks.Track;
using TrackRequest = Samples.MusicCollection.Api.Tracks.TrackRequest;
using TrackResponse = Samples.MusicCollection.Api.Tracks.TrackResponse;

namespace Samples.MusicCollection.Api.Tracks;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class TrackCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapPutV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPut
        (
            "/tracks/{id}",
            async Task<Results<Ok<TrackResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromBody] TrackRequest request,
				[FromServices] FluentValidation.IValidator<TrackRequest> validator,
                [FromServices] Samples.MusicCollection.Api.Tracks.ITracksCommandHandler handler,
                [FromServices] IMappingService<TrackRequest, Track> requestMappingService,
                [FromServices] IMappingService<Track, TrackResponse> responseMappingService
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

                Track model = requestMappingService.Map(request);

                if (model.TrackId != id)
                {
                    return TypedResults.BadRequest();
                }

                Track? updatedModel = await handler.UpdateTrackAsync(model).ConfigureAwait(false);

                if (updatedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                TrackResponse response = responseMappingService.Map(updatedModel);
                return TypedResults.Ok<TrackResponse>(response);
            }
        )
        .WithName("Tracks-Put-V1")
        .WithTags("tracks")
        .WithOpenApi(operation => new(operation) { Summary = "Puts a Track via a TrackRequest, mapped to a TrackResponse response." })
        .MapToApiVersion(1)
        .Accepts<TrackRequest>(MediaTypeNames.Application.Json)
        .Produces<TrackResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}