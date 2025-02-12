namespace MinimalApiGen.Generators.Generation.Query.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class QueryMappingRegistrationsBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="registrations"></param>
    /// <returns></returns>
    public static string Build(string registrations) =>
$@"using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class QueryMappingRegistrations
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""builder""></param>
    public static void AddQueryMappingServices(this WebApplicationBuilder builder)
    {{
{registrations}
    }}
}}";

    #endregion
}