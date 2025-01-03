namespace MinimalApiGen.Framework.Pagination;

/// <summary>
/// 
/// </summary>
public interface IPaginationQuery
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    int? PageSize { get; set; }

    /// <summary>
    /// 
    /// </summary>
    int? PageNumber { get; set; }

    /// <summary>
    /// 
    /// </summary>
    string? OrderBy { get; set; }

    /// <summary>
    /// 
    /// </summary>
    bool? OrderByAscending { get; set; }

    #endregion
}