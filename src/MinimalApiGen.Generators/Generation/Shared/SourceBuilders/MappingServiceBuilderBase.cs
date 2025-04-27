using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Shared.Results;
using System;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Shared.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="result"></param>
internal abstract class MappingServiceBuilderBase(IResult result)
{   
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Namespace { get; } = result.Namespace;

    /// <summary>
    /// 
    /// </summary>
    public string ModelName { get; } = result.ModelName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelFullyQualifiedName { get; } = result.ModelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string OperationName { get; } = result.OperationType.ToString();

    /// <summary>
    /// 
    /// </summary>
    public int Version { get; } = result.ApiVersion;

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ModelProperties { get; } = result.ModelProperties;

    /// <summary>
    /// 
    /// </summary>
    public abstract string MappingServiceName { get; }

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    /// <param name="sourceName"></param>
    /// <returns></returns>
    protected string BuildPropertyMap(EquatableArray<string> source, EquatableArray<string> target, string sourceName)
    {
        ReadOnlySpan<string> commonProperties = source.Where(sourceProperty => target.Any(targetProperty => targetProperty == sourceProperty)).ToArray();
        StringBuilder stringBuilder = new();
        foreach (string propertyName in commonProperties)
        {
            stringBuilder.Append("\t\t\t");
            stringBuilder.Append(propertyName);
            stringBuilder.Append(" = ");
            stringBuilder.Append(sourceName);
            stringBuilder.Append(".");
            stringBuilder.Append(propertyName);
            stringBuilder.AppendLine(",");
        }
        string propertyMap = stringBuilder.ToString();
        return propertyMap;
    }

    #endregion
}