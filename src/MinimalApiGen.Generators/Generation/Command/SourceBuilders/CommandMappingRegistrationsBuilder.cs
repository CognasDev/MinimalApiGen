namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class CommandMappingRegistrationsBuilder
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
public static class CommandMappingRegistrations
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""builder""></param>
    public static void UseCommandMappingServices(this WebApplicationBuilder builder)
    {{
{registrations}
    }}
}}";

    #endregion
}