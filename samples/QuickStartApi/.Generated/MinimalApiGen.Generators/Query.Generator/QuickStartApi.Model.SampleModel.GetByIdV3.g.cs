﻿using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

using SampleModel = QuickStartApi.Model.SampleModel;
using SampleModelResponse = QuickStartApi.Model.SampleModelResponse;

namespace QuickStartApi.V3;

/// <summary>
/// 
/// </summary>
public partial class SampleModelQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetByIdV3(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/samplemodels/{id}",
            async
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] QuickStartApi.V3.IBusinessLogicV3 businessLogic,
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
        .WithName("GetByIdSampleModelsV3")
        .WithTags("samplemodels")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of SampleModel by the id, mapped to a SampleModelResponse response." })
        .MapToApiVersion(3)
        .Produces<IEnumerable<SampleModelResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)
        .CacheOutput(builder => builder.Expire(TimeSpan.FromMinutes(5)));
     }
}