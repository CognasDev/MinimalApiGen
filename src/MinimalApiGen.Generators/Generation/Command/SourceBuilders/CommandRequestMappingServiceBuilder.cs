using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.Results;
using System;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="commandResult"></param>
internal sealed class CommandRequestMappingServiceBuilder(CommandResult commandResult)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ClassNamespace { get; } = commandResult.ClassNamespace;

    /// <summary>
    /// 
    /// </summary>
    public string ModelName { get; } = commandResult.ModelName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelFullyQualifiedName { get; } = commandResult.ModelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string OperationName { get; } = commandResult.CommandType.ToString();

    /// <summary>
    /// 
    /// </summary>
    public int Version { get; } = commandResult.Version;

    /// <summary>
    /// 
    /// </summary>
    public string RequestName { get; } = commandResult.RequestName;

    /// <summary>
    /// 
    /// </summary>
    public string RequestFullyQualifiedName { get; } = commandResult.RequestFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ModelProperties { get; } = commandResult.ModelProperties;

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> RequestProperties { get; } = commandResult.RequestProperties;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string Build() =>
$@"using MinimalApiGen.Framework.Mapping;
using {ModelName} = {ModelFullyQualifiedName};
using {RequestName} = {RequestFullyQualifiedName};

namespace {ClassNamespace};

/// <summary>
/// 
/// </summary>
public sealed class {OperationName}{RequestName}To{ModelName}MappingServiceV{Version} : MappingServiceBase<{RequestName}, {ModelName}>
{{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""request""></param>
    /// <returns></returns>
    public override {ModelName} Map({RequestName} request)
    {{
        {ModelName} model = new()
        {{
{BuildPropertyMap()}
        }};
        return model;
    }}

    #endregion
}}";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string BuildPropertyMap()
    {
        ReadOnlySpan<string> commonProperties = RequestProperties.Where
                                                                (
                                                                    requestProperty => ModelProperties.Any(modelProperty => modelProperty == requestProperty)
                                                                )
                                                               .Select(modelProperty => modelProperty)
                                                               .ToArray();

        StringBuilder stringBuilder = new();
        foreach (string propertyName in commonProperties)
        {
            stringBuilder.Append("\t\t\t");
            stringBuilder.Append(propertyName);
            stringBuilder.Append(" = request.");
            stringBuilder.Append(propertyName);
            stringBuilder.AppendLine(",");
        }
        string propertyMap = stringBuilder.ToString();
        return propertyMap;
    }

    #endregion
}