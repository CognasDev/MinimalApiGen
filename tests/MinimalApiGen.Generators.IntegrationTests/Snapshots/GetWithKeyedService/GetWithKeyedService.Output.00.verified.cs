//HintName: MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel.GetV1.g.cs
using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using SampleModel = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel;
using SampleModelResponse = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelResponse;

namespace MinimalApiGen.Generators.IntegrationTests.Fixtures;

/// <summary>
/// 
/// </summary>
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
                [FromServices] MinimalApiGen.Generators.IntegrationTests.Fixtures.IServiceBusinessLogic businessLogic,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> mappingService,
				[FromKeyedServices("SampleService1")] MinimalApiGen.Generators.IntegrationTests.Fixtures.ISampleService1 sampleService1
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<SampleModelResponse> SampleModelResponseStreamAsync()
                {
                    IEnumerable<SampleModel> models = await businessLogic.GetModelsAsync(sampleService1, cancellationToken).ConfigureAwait(false);
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
        .WithName("GetSampleModelsV1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of SampleModels mapped to SampleModelResponse responses." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}