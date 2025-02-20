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
internal sealed class ResponseMappingServiceBuilder(IResult result)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ClassNamespace { get; } = result.ClassNamespace;

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
    public int Version { get; } = result.Version;

    /// <summary>
    /// 
    /// </summary>
    public string ResponseName { get; } = result.ResponseName;

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; } = result.ResponseFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ModelProperties { get; } = result.ModelProperties;

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ResponseProperties { get; } = result.ResponseProperties;

    /// <summary>
    /// 
    /// </summary>
    public string MappingServiceName => $"{OperationName}{ModelName}To{ResponseName}MappingServiceV{Version}";

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
public sealed class {MappingServiceName} : MappingServiceBase<{ModelName}, {ResponseName}>
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