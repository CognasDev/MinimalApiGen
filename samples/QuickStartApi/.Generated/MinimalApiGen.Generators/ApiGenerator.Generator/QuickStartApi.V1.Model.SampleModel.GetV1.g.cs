using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using SampleModel = QuickStartApi.V1.Model.SampleModel;
using SampleModelResponse = QuickStartApi.V1.Model.SampleModelResponse;

namespace QuickStartApi.V1.Query;

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
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/samplemodels",
            (
                CancellationToken cancellationToken,
                [FromServices] QuickStartApi.V1.Query.IQueryBusinessLogicV1 businessLogic,
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
        .WithName("SampleModels-Get-V1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of SampleModels mapped to SampleModelResponse responses." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}