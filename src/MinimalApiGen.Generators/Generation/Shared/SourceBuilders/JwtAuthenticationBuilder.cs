namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
public static class JwtAuthenticationBuilder
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static string Build() =>
$@"
        .RequireAuthorization()";

    #endregion
}