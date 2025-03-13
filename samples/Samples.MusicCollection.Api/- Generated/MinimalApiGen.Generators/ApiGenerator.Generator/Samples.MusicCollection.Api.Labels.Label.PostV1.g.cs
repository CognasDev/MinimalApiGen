using Microsoft.AspNetCore.Http.HttpResults;
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
    public virtual RouteHandlerBuilder MapPostV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPost
        (
            "/labels",
            async Task<Results<CreatedAtRoute<LabelResponse>, BadRequest, ValidationProblem>>
            (
                CancellationToken cancellationToken,
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
                Label? insertedModel = await handler.InsertLabelAsync(model).ConfigureAwait(false);

                if (insertedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                LabelResponse response = responseMappingService.Map(insertedModel);
                string routeName = "Labels-GetById-V1";
                int? newId = insertedModel.LabelId ?? throw new NullReferenceException();
                return TypedResults.CreatedAtRoute<LabelResponse>(response, routeName, new {id = newId});
            }
        )
        .WithName("Labels-Post-V1")
        .WithTags("labels")
        .WithOpenApi(operation => new(operation) { Summary = "Posts a Label via a LabelRequest, mapped to a LabelResponse response." })
        .MapToApiVersion(1)
        .Accepts<LabelRequest>(MediaTypeNames.Application.Json)
        .Produces<LabelResponse>(StatusCodes.Status201Created, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}