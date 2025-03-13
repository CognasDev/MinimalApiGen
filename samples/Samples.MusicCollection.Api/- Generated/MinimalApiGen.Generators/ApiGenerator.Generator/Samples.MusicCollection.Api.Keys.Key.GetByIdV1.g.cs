using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using Key = Samples.MusicCollection.Api.Keys.Key;
using KeyResponse = Samples.MusicCollection.Api.Keys.KeyResponse;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class KeyQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetByIdV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/keys/{id}",
            async Task<Results<Ok<KeyResponse>, NotFound>>
            (
                CancellationToken cancellationToken,
                [FromRoute] int id,
                [FromServices] Samples.MusicCollection.Api.Keys.IKeysQueryHandler handler,
                [FromServices] IMappingService<Key, KeyResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));

                Key? model = await handler.SelectKeyAsync(id).ConfigureAwait(false);

                if (model is null)
                {
                    return TypedResults.NotFound();
                }

                KeyResponse response = mappingService.Map(model);
                return TypedResults.Ok(response);
            }
        )
        .WithName("Keys-GetById-V1")
        .WithTags("keys")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a single model of a Key by the id, mapped to a KeyResponse response." })
        .MapToApiVersion(1)
        .Produces<KeyResponse>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)
        .CacheOutput(builder => builder.Expire(TimeSpan.FromHours(1)));
     }
}