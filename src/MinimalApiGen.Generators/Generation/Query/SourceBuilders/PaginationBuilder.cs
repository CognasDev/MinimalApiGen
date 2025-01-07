namespace MinimalApiGen.Generators.Generation.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
public static class PaginationBuilder
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public static string PaginationComment { get; } = " Pagination is supported.";

    /// <summary>
    /// 
    /// </summary>
    public static string PaginationUsings { get; } =
@"using MinimalApiGen.Framework.Pagination;
using System.ComponentModel;";

    /// <summary>
    /// 
    /// </summary>
    public static string PaginationServiceAndQuery { get; } = @",
                [FromServices] IPaginationService paginationService,
                [AsParameters] PaginationQuery paginationQuery";

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="responseName"></param>
    /// <returns></returns>
    public static string Build(string responseName) =>
$@"
                    if (paginationService.IsPaginationQueryValidOrNotRequested<{responseName}>(paginationQuery) == true)
                    {{
                        PropertyDescriptor orderByProperty = paginationService.OrderByProperty<{responseName}>(paginationQuery);
                        int takeQuantity = paginationService.TakeQuantity(paginationQuery);
                        int skipNumber = paginationService.SkipNumber(paginationQuery);

                        if (paginationQuery.OrderByAscending ?? true)
                        {{
                            responses = responses.OrderBy(response => orderByProperty.GetValue(response)).Skip(skipNumber).Take(takeQuantity);
                        }}
                        else
                        {{
                            responses = responses.OrderByDescending(response => orderByProperty.GetValue(response)).Skip(skipNumber).Take(takeQuantity);
                        }}
                    }}
";

    #endregion
}