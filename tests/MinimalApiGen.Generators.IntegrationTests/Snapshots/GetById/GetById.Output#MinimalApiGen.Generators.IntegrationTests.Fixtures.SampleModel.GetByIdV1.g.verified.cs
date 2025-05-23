﻿//HintName: MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel.GetByIdV1.g.cs
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
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
            async Task<Results<Ok<SampleModelResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] MinimalApiGen.Generators.IntegrationTests.Fixtures.ISimpleHandler handler,
                [FromServices] IMappingService<SampleModel, SampleModelResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                SampleModel? model = await handler.GetModelByIdAsync(id, cancellationToken).ConfigureAwait(false);

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
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of a SampleModel by the id, mapped to a SampleModelResponse response." })
        .MapToApiVersion(1)
        .Produces<SampleModelResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}