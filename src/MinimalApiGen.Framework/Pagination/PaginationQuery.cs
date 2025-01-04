using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinimalApiGen.Framework.Pagination;

/// <summary>
/// 
/// </summary>
public sealed record PaginationQuery : IPaginationQuery
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [FromQuery(Name = "pageSize")]
    [JsonPropertyName("pageSize")]
    [Range(1, 50)]
    public required int? PageSize { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [FromQuery(Name = "pageNumber")]
    [JsonPropertyName("pageNumber")]
    public required int? PageNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [FromQuery(Name = "orderBy")]
    [JsonPropertyName("orderBy")]
    [StringLength(250)]
    public required string? OrderBy { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [FromQuery(Name = "orderByAscending")]
    [JsonPropertyName("orderByAscending")]
    public required bool? OrderByAscending { get; set; }

    #endregion
}