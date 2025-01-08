using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using SampleModel = QuickStartApi.Model.SampleModel;
using SampleModelResponse = QuickStartApi.Model.SampleModelResponse;

namespace QuickStartApi.V3;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class SampleModelQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetV3(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/samplemodels",
            (
                CancellationToken cancellationToken,
                [FromServices] QuickStartApi.V3.IBusinessLogicV3 businessLogic,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<SampleModelResponse> SampleModelResponseStreamAsync()
                {
                    IEnumerable<SampleModel> models = await businessLogic.GetModelsAsync(cancellationToken).ConfigureAwait(false);
                    IEnumerable<SampleModelResponse> responses = mappingService.Map(models);

                    foreach (SampleModelResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return SampleModelResponseStreamAsync();   
            }
        )
        .WithName("GetSampleModelsV3")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of SampleModels mapped to SampleModelResponse responses." })
        .MapToApiVersion(3)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}