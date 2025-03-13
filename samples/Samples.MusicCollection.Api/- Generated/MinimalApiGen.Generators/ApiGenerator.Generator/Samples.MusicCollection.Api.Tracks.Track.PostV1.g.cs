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
    public virtual RouteHandlerBuilder MapPostV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPost
        (
            "/tracks",
            async Task<Results<CreatedAtRoute<TrackResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
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
                Track? insertedModel = await handler.InsertTrackAsync(model).ConfigureAwait(false);

                if (insertedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                TrackResponse response = responseMappingService.Map(insertedModel);
                string routeName = "Tracks-GetById-V1";
                int? newId = insertedModel.TrackId ?? throw new NullReferenceException();
                return TypedResults.CreatedAtRoute<TrackResponse>(response, routeName, new {id = newId});
            }
        )
        .WithName("Tracks-Post-V1")
        .WithTags("tracks")
        .WithOpenApi(operation => new(operation) { Summary = "Posts a Track via a TrackRequest, mapped to a TrackResponse response." })
        .MapToApiVersion(1)
        .Accepts<TrackRequest>(MediaTypeNames.Application.Json)
        .Produces<TrackResponse>(StatusCodes.Status201Created, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}