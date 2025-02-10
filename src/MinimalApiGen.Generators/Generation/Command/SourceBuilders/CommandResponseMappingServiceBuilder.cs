using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Query.Results;
using System;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="commandResult"></param>
internal sealed class CommandResponseMappingServiceBuilder(CommandResult commandResult)
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
    public string ResponseName { get; } = commandResult.ResponseName;

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; } = commandResult.ResponseFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ModelProperties { get; } = commandResult.ModelProperties;

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ResponseProperties { get; } = commandResult.ResponseProperties;

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string Build() =>
$@"using MinimalApiGen.Framework.Mapping;
using {ModelName} = {ModelFullyQualifiedName};
using {ResponseName} = {ResponseFullyQualifiedName};

namespace {ClassNamespace};

/// <summary>
/// 
/// </summary>
public sealed class {OperationName}{ModelName}To{ResponseName}MappingServiceV{Version} : MappingServiceBase<{ModelName}, {ResponseName}>
{{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""model""></param>
    /// <returns></returns>
    public override {ResponseName} Map({ModelName} model)
    {{
        {ResponseName} response = new()
        {{
{BuildPropertyMap()}
        }};
        return response;
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
        ReadOnlySpan<string> commonProperties = ModelProperties.Where
                                                                (
                                                                    modelProperty => ResponseProperties.Any(responseProperty => responseProperty == modelProperty)
                                                                )
                                                               .Select(modelProperty => modelProperty)
                                                               .ToArray();

        StringBuilder stringBuilder = new();
        foreach (string propertyName in commonProperties)
        {
            stringBuilder.Append("\t\t\t");
            stringBuilder.Append(propertyName);
            stringBuilder.Append(" = model.");
            stringBuilder.Append(propertyName);
            stringBuilder.AppendLine(",");
        }
        string propertyMap = stringBuilder.ToString();
        return propertyMap;
    }

    #endregion
}