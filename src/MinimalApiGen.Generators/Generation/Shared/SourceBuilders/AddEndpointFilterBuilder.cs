namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
public static class AddEndpointFilterBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterFullyQualifiedName"></param>
    /// <returns></returns>
    public static string Build(string filterFullyQualifiedName) =>
$@"
        .AddEndpointFilter<{filterFullyQualifiedName}>()";

    #endregion
}