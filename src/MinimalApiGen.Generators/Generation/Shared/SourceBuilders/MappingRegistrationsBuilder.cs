namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class MappingRegistrationsBuilder
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
public static class MappingRegistrations
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""builder""></param>
    public static void AddMinimalApiFramewokMappingServices(this WebApplicationBuilder builder)
    {{
{registrations}
    }}
}}";

    #endregion
}