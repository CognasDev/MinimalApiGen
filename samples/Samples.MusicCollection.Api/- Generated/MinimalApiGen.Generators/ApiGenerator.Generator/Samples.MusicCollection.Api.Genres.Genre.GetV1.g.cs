using MinimalApiGen.Framework.Mapping;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using MinimalApiGen.Framework.Pagination;
using System.ComponentModel;
using Genre = Samples.MusicCollection.Api.Genres.Genre;
using GenreResponse = Samples.MusicCollection.Api.Genres.GenreResponse;

namespace Samples.MusicCollection.Api.Genres;

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class GenreQueryRouteEndpointsMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="endpointRouteBuilder"></param>
    public virtual RouteHandlerBuilder MapGetV1(IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder.MapGet
        (
            "/genres",
            (
                CancellationToken cancellationToken,
                [FromServices] Samples.MusicCollection.Api.Genres.IGenresQueryHandler handler,
                [FromServices] IMappingService<Genre, GenreResponse> mappingService,
                [FromServices] IPaginationService paginationService,
                [AsParameters] PaginationQuery paginationQuery
            ) =>
            {
                ArgumentNullException.ThrowIfNull(handler, nameof(handler));
                ArgumentNullException.ThrowIfNull(mappingService, nameof(mappingService));
                async IAsyncEnumerable<GenreResponse> GenreResponseStreamAsync()
                {
                    IEnumerable<Genre> models = await handler.SelectGenresAsync().ConfigureAwait(false);
                    IEnumerable<GenreResponse> responses = mappingService.Map(models);

                    if (paginationService.IsPaginationQueryValidOrNotRequested<GenreResponse>(paginationQuery) == true)
                    {
                        PropertyDescriptor orderByProperty = paginationService.OrderByProperty<GenreResponse>(paginationQuery);
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

                    foreach (GenreResponse response in responses)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        yield return response;
                    }
                }
                return GenreResponseStreamAsync();   
            }
        )
        .WithName("Genres-Get-V1")
        .WithTags("genres")
        .WithOpenApi(operation => new(operation) { Summary = "Gets a collection of Genres mapped to GenreResponse responses. Pagination is supported." })
        .MapToApiVersion(1)
        .Produces<IEnumerable<GenreResponse>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }
}