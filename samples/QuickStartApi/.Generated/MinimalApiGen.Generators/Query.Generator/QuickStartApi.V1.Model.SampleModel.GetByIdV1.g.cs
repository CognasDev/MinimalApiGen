using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
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
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/samplemodels/{id}",
            async Task<Results<Ok<SampleModelResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] QuickStartApi.V1.Query.IQueryBusinessLogicV1 businessLogic,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                SampleModel? model = await businessLogic.GetModelByIdAsync(id, cancellationToken).ConfigureAwait(false);

                if (model is null)
                {
                    return TypedResults.NotFound();
                }

                SampleModelResponse response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }
        )
        .WithName("SampleModels-GetById-V1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of SampleModel by the id, mapped to a SampleModelResponse response." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)
        .CacheOutput(builder => builder.Expire(TimeSpan.FromMinutes(5)));
     }
}