using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using SampleModel = Samples.QuickStartApi.V1.Model.SampleModel;

namespace Samples.QuickStartApi.V1.Command;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class SampleModelCommandRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapDeleteV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapDelete
        (
            "/samplemodels/{id}",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.QuickStartApi.V1.Command.ICommandHandlerV1 handler
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                await handler.DeleteModelAsync(id, cancellationToken);
                return TypedResults.NoContent();
            }
        )
        .WithName("SampleModels-Delete-V1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Deletes a SampleModel via the id." })
        .MapToApiVersion(1)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)
        .RequireAuthorization();
     }
}