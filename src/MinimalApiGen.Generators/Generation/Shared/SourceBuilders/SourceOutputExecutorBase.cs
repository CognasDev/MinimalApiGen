using System.Collections.Generic;

namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
internal abstract class SourceOutputExecutorBase
{
    #region Field Declarations

    private readonly static HashSet<string> _responseMappingServices = [];

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelName"></param>
    /// <param name="responseName"></param>
    /// <param name="apiVersion"></param>
    /// <returns></returns>
    protected static string BuildResponseMappingServiceName(string modelName, string responseName, int apiVersion)
        => $"{modelName}{responseName}.MappingSericeV{apiVersion}.g.cs";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    protected static bool IsMappingServiceGenerated(string name)
    {
        if (!_responseMappingServices.Contains(name))
        {
            _responseMappingServices.Add(name);
            return false;
        }
        return true;
    }

    #endregion
}