namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal static class MappingServicesBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sourceFullyQualifiedName"></param>
    /// <param name="targetFullyQualifiedName"></param>
    /// <param name="mappingServiceNamespace"></param>
    /// <param name="mappingServiceName"></param>
    /// <returns></returns>
    public static string Build(string sourceFullyQualifiedName, string targetFullyQualifiedName, string mappingServiceNamespace, string mappingServiceName) =>
$@"using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public partial class MappingServicesDependencies
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""builder""></param>
    partial void UseMappingServices(WebApplicationBuilder builder)
    {{
        builder.Services.AddSingleton<IMappingService<{sourceFullyQualifiedName}, {targetFullyQualifiedName}>, {mappingServiceNamespace}.{mappingServiceName}>();
    }}
}}";

    #endregion
}