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
internal sealed class ResponseMappingServiceBuilder(IResult result) : MappingServiceBuilderBase(result)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ResponseName { get; } = !string.IsNullOrWhiteSpace(result.ResponseName) ? result.ResponseName! : throw new ArgumentNullException(nameof(IResult.ResponseName));

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; } = !string.IsNullOrWhiteSpace(result.ResponseFullyQualifiedName) ? result.ResponseFullyQualifiedName! : throw new ArgumentNullException(nameof(IResult.ResponseFullyQualifiedName));

    /// <summary>
    /// 
    /// </summary>
    public EquatableArray<string> ResponseProperties { get; } = result.ResponseProperties;

    /// <summary>
    /// 
    /// </summary>
    public override string MappingServiceName => $"{OperationName}{ModelName}To{ResponseName}MappingServiceV{Version}";

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

namespace {Namespace};

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
{BuildPropertyMap(ModelProperties, ResponseProperties, "model")}
        }};
        return response;
    }}

    #endregion
}}";

    #endregion
}