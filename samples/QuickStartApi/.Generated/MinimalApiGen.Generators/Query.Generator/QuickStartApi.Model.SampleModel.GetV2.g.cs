using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MinimalApiGen.Framework.Pagination;
using System.ComponentModel;
using SampleModel = QuickStartApi.Model.SampleModel;
using SampleModelResponse = QuickStartApi.Model.SampleModelResponse;

namespace QuickStartApi.V2;

/// <summary>
/// 
/// </summary>
public partial class SampleModelQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetV2(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/samplemodels",
            (
                CancellationToken cancellationToken,
                [FromServices] QuickStartApi.V2.IBusinessLogicV2 businessLogic,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> mappingService,
				[FromServices] QuickStartApi.Services.SampleService1 sampleService1,
				[FromServices] QuickStartApi.Services.SampleService2 sampleService2,
				[FromKeyedServices("SampleKeyedService")] QuickStartApi.Services.SampleKeyedService sampleKeyedService,
                [FromServices] IPaginationService paginationService,
                [AsParameters] PaginationQuery paginationQuery
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<SampleModelResponse> SampleModelResponseStreamAsync()
                {
                    IEnumerable<SampleModel> models = await businessLogic.GetModelsAsync(sampleService1, sampleKeyedService, cancellationToken).ConfigureAwait(false);
                    IEnumerable<SampleModelResponse> responses = mappingService.Map(models);

                    if (paginationService.IsPaginationQueryValidOrNotRequested<SampleModelResponse>(paginationQuery) == true)
                    {
                        PropertyDescriptor orderByProperty = paginationService.OrderByProperty<SampleModelResponse>(paginationQuery);
                        int takeQuantity = paginationService.TakeQuantity(paginationQuery);
                        int skipNumber = paginationService.SkipNumber(paginationQuery);

                        if (paginationQuery.OrderByAscending ?? true)
                        {
                            responses = responses.OrderBy(response => orderByProperty.GetValue(response)).Skip(skipNumber).Take(takeQuantity);
                        }
                        else
                        {
                            responses = responses.OrderByDescending(response => orderByProperty.GetValue(response)).Skip(skipNumber).Take(takeQuantity);
                        }
                    }

                    foreach (SampleModelResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return SampleModelResponseStreamAsync();   
            }
        )
        .WithName("GetSampleModelsV2")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of SampleModels mapped to SampleModelResponse responses. Pagination is supported." })
        .MapToApiVersion(2)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)
        .CacheOutput(builder => builder.Expire(TimeSpan.FromMinutes(3)));
     }
}