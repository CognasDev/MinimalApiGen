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
    public virtual RouteHandlerBuilder MapPostV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapPost
        (
            "/samplemodels",
            async Task<Results<CreatedAtRoute<SampleModelResponse>, BadRequest>>
            (
                CancellationToken cancellationToken,
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
                SampleModel? insertedModel = await businessLogic.PostModelAsync(model, cancellationToken).ConfigureAwait(false);

                if (insertedModel is null)
                {
                    return TypedResults.BadRequest();
                }

                SampleModelResponse response = responseMappingService.Map(insertedModel);
                string routeName = "SampleModels-GetById-V1";
                int? newId = insertedModel.Id ?? throw new NullReferenceException();
                return TypedResults.CreatedAtRoute<SampleModelResponse>(response, routeName, new {id = newId});
            }
        )
        .WithName("SampleModels-Post-V1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Posts a SampleModel via a SampleModelRequest, mapped to a SampleModelResponse response." })
        .MapToApiVersion(1)
        .Accepts<SampleModelRequest>(MediaTypeNames.Application.Json)
        .Produces<SampleModelResponse>(StatusCodes.Status201Created, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}