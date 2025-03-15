using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
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
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/keys",
            (
                CancellationToken cancellationToken,
                [FromServices] Samples.MusicCollection.Api.Keys.IKeysQueryHandler handler,
                [FromServices] IMappingService<Key, KeyResponse> mappingService
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<KeyResponse> KeyResponseStreamAsync()
                {
                    IEnumerable<Key> models = await handler.SelectKeysAsync().ConfigureAwait(false);
                    IEnumerable<KeyResponse> responses = mappingService.Map(models);

                    foreach (KeyResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return KeyResponseStreamAsync();   
            }
        )
        .WithName("Keys-Get-V1")
        .WithTags("keys")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of Keys mapped to KeyResponse responses." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<KeyResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json)
        .CacheOutput(builder => builder.Expire(TimeSpan.FromHours(1)));
     }
}