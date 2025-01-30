using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal abstract class SourceOutputExecutorBase
{
    #region Field Declarations

    private static readonly object _lock = new();
    private readonly static HashSet<string> _responseMappingServices = [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    protected static string BuildMappingServiceName(string source, string target, int apiVersion)
        => $"{source}.{target}.MappingSericeV{apiVersion}.g.cs";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    protected static bool IsMappingServiceGenerated(string name)
    {
        lock (_lock)
        {
            if (!_responseMappingServices.Contains(name))
            {
                _responseMappingServices.Add(name);
                return false;
            }
            return true;
        }
    }

    #endregion
}