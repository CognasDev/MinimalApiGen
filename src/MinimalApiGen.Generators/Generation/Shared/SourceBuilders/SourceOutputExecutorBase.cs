namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal abstract class SourceOutputExecutorBase
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="operationName"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    protected static string BuildMappingServiceName(string source, string target, string operationName, int apiVersion)
        => $"{source}.{target}.{operationName}MappingServiceV{apiVersion}.g.cs";

    #endregion
}