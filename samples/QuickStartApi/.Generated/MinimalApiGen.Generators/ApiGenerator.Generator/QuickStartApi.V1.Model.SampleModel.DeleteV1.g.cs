using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using SampleModel = QuickStartApi.V1.Model.SampleModel;
using SampleModelRequest = QuickStartApi.V1.Model.SampleModelRequest;

namespace QuickStartApi.V1.Command;

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
            "/samplemodels",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromBody] SampleModelRequest request,
                [FromServices] QuickStartApi.V1.Command.ICommandBusinessLogicV1 businessLogic,
                [FromServices] IMappingService<SampleModelRequest, SampleModel> requestMappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(requestMappingService, nameof(requestMappingService));

                SampleModel model = requestMappingService.Map(request);
                await businessLogic.DeleteModelAsync(model, cancellationToken).ConfigureAwait(false);

                return TypedResults.NoContent();
            }
        )
        .WithName("SampleModels-Delete-V1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Deletes a SampleModel via a SampleModelRequest." })
        .MapToApiVersion(1)
        .Accepts<SampleModelRequest>(MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}