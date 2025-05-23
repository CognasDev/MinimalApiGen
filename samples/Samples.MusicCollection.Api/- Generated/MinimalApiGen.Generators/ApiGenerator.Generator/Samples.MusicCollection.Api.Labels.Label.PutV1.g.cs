﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Label = Samples.MusicCollection.Api.Labels.Label;
using LabelRequest = Samples.MusicCollection.Api.Labels.LabelRequest;
using LabelResponse = Samples.MusicCollection.Api.Labels.LabelResponse;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class LabelCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapPutV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPut
        (
            "/labels/{id}",
            async Task<Results<Ok<LabelResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromBody] LabelRequest request,
				[FromServices] FluentValidation.IValidator<LabelRequest> validator,
                [FromServices] Samples.MusicCollection.Api.Labels.ILabelsCommandHandler handler,
                [FromServices] IMappingService<LabelRequest, Label> requestMappingService,
                [FromServices] IMappingService<Label, LabelResponse> responseMappingService
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

                Label model = requestMappingService.Map(request);

                if (model.LabelId != id)
                {
                    return TypedResults.BadRequest();
                }

                Label? updatedModel = await handler.UpdateLabelAsync(model).ConfigureAwait(false);

                if (updatedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                LabelResponse response = responseMappingService.Map(updatedModel);
                return TypedResults.Ok<LabelResponse>(response);
            }
        )
        .WithName("Labels-Put-V1")
        .WithTags("labels")
        .WithOpenApi(operation => new(operation) { Summary = "Puts a Label via a LabelRequest, mapped to a LabelResponse response." })
        .MapToApiVersion(1)
        .Accepts<LabelRequest>(MediaTypeNames.Application.Json)
        .Produces<LabelResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}