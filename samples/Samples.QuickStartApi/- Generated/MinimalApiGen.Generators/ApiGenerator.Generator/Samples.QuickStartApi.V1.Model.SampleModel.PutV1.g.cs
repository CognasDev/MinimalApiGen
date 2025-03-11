using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using SampleModel = Samples.QuickStartApi.V1.Model.SampleModel;
using SampleModelRequest = Samples.QuickStartApi.V1.Model.SampleModelRequest;
using SampleModelResponse = Samples.QuickStartApi.V1.Model.SampleModelResponse;

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
    public virtual RouteHandlerBuilder MapPutV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPut
        (
            "/samplemodels/{id}",
            async Task<Results<Ok<SampleModelResponse>, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromBody] SampleModelRequest request,
                [FromServices] Samples.QuickStartApi.V1.Command.ICommandBusinessLogicV1 businessLogic,
                [FromServices] IMappingService<SampleModelRequest, SampleModel> requestMappingService,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> responseMappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(requestMappingService, nameof(requestMappingService));
                ArgumentNullException.ThrowIfNull(responseMappingService, nameof(responseMappingService));
                
                SampleModel model = requestMappingService.Map(request);

                if (model.Id != id)
                {
                    return TypedResults.BadRequest();
                }

                SampleModel? updatedModel = await businessLogic.PutModelAsync(model, cancellationToken).ConfigureAwait(false);

                if (updatedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                SampleModelResponse response = responseMappingService.Map(updatedModel);
                return TypedResults.Ok<SampleModelResponse>(response);
            }
        )
        .WithName("SampleModels-Put-V1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Puts a SampleModel via a SampleModelRequest, mapped to a SampleModelResponse response." })
        .MapToApiVersion(1)
        .Accepts<SampleModelRequest>(MediaTypeNames.Application.Json)
        .Produces<SampleModelResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)
        .RequireAuthorization();
     }
}