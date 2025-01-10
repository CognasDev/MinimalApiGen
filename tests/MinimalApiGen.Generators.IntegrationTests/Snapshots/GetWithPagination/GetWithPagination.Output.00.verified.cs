//HintName: MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel.GetV1.g.cs
using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MinimalApiGen.Framework.Pagination;
using System.ComponentModel;
using SampleModel = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel;
using SampleModelResponse = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelResponse;

namespace MinimalApiGen.Generators.IntegrationTests.Fixtures;

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
                [FromServices] MinimalApiGen.Generators.IntegrationTests.Fixtures.ISimpleBusinessLogic businessLogic,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> mappingService,
                [FromServices] IPaginationService paginationService,
                [AsParameters] PaginationQuery paginationQuery
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<SampleModelResponse> SampleModelResponseStreamAsync()
                {
                    IEnumerable<SampleModel> models = await businessLogic.GetModelsAsync(cancellationToken).ConfigureAwait(false);
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
        .WithName("SampleModels-Get-V1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of SampleModels mapped to SampleModelResponse responses. Pagination is supported." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}