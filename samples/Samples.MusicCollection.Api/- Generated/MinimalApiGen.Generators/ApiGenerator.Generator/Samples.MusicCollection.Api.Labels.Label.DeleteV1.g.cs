using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Label = Samples.MusicCollection.Api.Labels.Label;
using LabelRequest = Samples.MusicCollection.Api.Labels.LabelRequest;
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
    public virtual RouteHandlerBuilder MapDeleteV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapDelete
        (
            "/labels/{id}",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromBody] LabelRequest request,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Labels.ILabelsCommandHandler handler
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(request, nameof(request));
                await handler.DeleteLabelAsync(id).ConfigureAwait(false);
                return TypedResults.NoContent();
            }
        )
        .WithName("Labels-Delete-V1")
        .WithTags("labels")
        .WithOpenApi(operation => new(operation) { Summary = "Deletes a Label via the id." })
        .MapToApiVersion(1)
        .Accepts<LabelRequest>(MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}