using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Linq;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="commandResult"></param>
internal sealed class CommandRequestMappingServiceBuilder(ICommandResult commandResult) : MappingServiceBuilderBase(commandResult)
{
    #region Property Declarations

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
    public EquatableArray<string> RequestProperties { get; } = commandResult.RequestProperties;

    /// <summary>
    /// 
    /// </summary>
    public override string MappingServiceName => $"{OperationName}{RequestName}To{ModelName}MappingServiceV{Version}";

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

namespace {Namespace};

/// <summary>
/// 
/// </summary>
public sealed class {MappingServiceName} : MappingServiceBase<{RequestName}, {ModelName}>
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
{BuildPropertyMap(RequestProperties, ModelProperties, "request")}
        }};
        return model;
    }}

    #endregion
}}";

    #endregion
}