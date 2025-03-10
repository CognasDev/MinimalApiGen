using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MinimalApiGen.Framework.Pagination;
using System.ComponentModel;
using Label = Samples.MusicCollection.Api.Labels.Label;
using LabelResponse = Samples.MusicCollection.Api.Labels.LabelResponse;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class LabelQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/labels",
            (
                CancellationToken cancellationToken,
                [FromServices] Samples.MusicCollection.Api.Labels.ILabelsQueryBusinessLogic businessLogic,
                [FromServices] IMappingService<Label, LabelResponse> mappingService,
                [FromServices] IPaginationService paginationService,
                [AsParameters] PaginationQuery paginationQuery
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<LabelResponse> LabelResponseStreamAsync()
                {
                    IEnumerable<Label> models = await businessLogic.SelectLabelsAsync().ConfigureAwait(false);
                    IEnumerable<LabelResponse> responses = mappingService.Map(models);

                    if (paginationService.IsPaginationQueryValidOrNotRequested<LabelResponse>(paginationQuery) == true)
                    {
                        PropertyDescriptor orderByProperty = paginationService.OrderByProperty<LabelResponse>(paginationQuery);
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

                    foreach (LabelResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return LabelResponseStreamAsync();   
            }
        )
        .WithName("Labels-Get-V1")
        .WithTags("labels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of Labels mapped to LabelResponse responses. Pagination is supported." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<LabelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}