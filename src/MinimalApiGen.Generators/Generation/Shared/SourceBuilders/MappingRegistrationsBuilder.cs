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
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="mappingServiceFullyQualifiedName"></param>
    /// <returns></returns>
    public static string Build(string source, string target, string mappingServiceFullyQualifiedName) => $"\t\tbuilder.Services.AddSingleton<IMappingService<{source}, {target}>, {mappingServiceFullyQualifiedName}>();";

    #endregion
}