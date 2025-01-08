//HintName: MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel.GetByIdV1.g.cs
using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/samplemodels/{id}",
            async
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] MinimalApiGen.Generators.IntegrationTests.Fixtures.ISimpleBusinessLogic businessLogic,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                SampleModel? model = await businessLogic.GetModelByIdAsync(id, cancellationToken).ConfigureAwait(false);

                if (model is null)
                {
                    return Results.NotFound();
                }

                SampleModelResponse response = mappingService.Map(model);
                return Results.Ok(response);
            }
        )
        .WithName("GetByIdSampleModelsV1")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of SampleModel by the id, mapped to a SampleModelResponse response." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}