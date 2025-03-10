using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Label = Samples.MusicCollection.Api.Labels.Label;
using LabelResponse = Samples.MusicCollection.Api.Labels.LabelResponse;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class LabelQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/labels/{id}",
            async Task<Results<Ok<LabelResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Labels.ILabelsQueryBusinessLogic businessLogic,
                [FromServices] IMappingService<Label, LabelResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                Label? model = await businessLogic.SelectLabelAsync(id).ConfigureAwait(false);

                if (model is null)
                {
                    return TypedResults.NotFound();
                }

                LabelResponse response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }
        )
        .WithName("Labels-GetById-V1")
        .WithTags("labels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of a Label by the id, mapped to a LabelResponse response." })
        .MapToApiVersion(1)
        .Produces<LabelResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}