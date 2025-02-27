using MinimalApiGen.Generators.Equality;
using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="commandResult"></param>
/// <param name="servicesBuilder"></param>
internal sealed class MapDeleteBuilder(ICommandResult commandResult, ServicesBuilder servicesBuilder)
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string ClassName { get; } = commandResult.ClassName;

    /// <summary>
    /// 
    /// </summary>
    public string ClassNamespace { get; } = commandResult.ClassNamespace;

    /// <summary>
    /// 
    /// </summary>
    public int ApiVersion { get; } = commandResult.ApiVersion;

    /// <summary>
    /// 
    /// </summary>
    public string ModelName { get; } = commandResult.ModelName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralName { get; } = commandResult.ModelPluralName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelPluralNameLower => ModelPluralName.ToLowerInvariant();

    /// <summary>
    /// 
    /// </summary>
    public string ModelFullyQualifiedName { get; } = commandResult.ModelFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyName { get; } = commandResult.ModelIdPropertyName;

    /// <summary>
    /// 
    /// </summary>
    public string ModelIdPropertyType { get; } = commandResult.ModelIdPropertyType;

    /// <summary>
    /// 
    /// </summary>
    public string? ModelIdUnderlyingPropertyType { get; } = commandResult.ModelIdUnderlyingPropertyType;

    /// <summary>
    /// 
    /// </summary>
    public string FromServices { get; } = servicesBuilder.FromServices;

    /// <summary>
    /// 
    /// </summary>
    public string FromKeyedServices { get; } = servicesBuilder.FromKeyedServices;

    /// <summary>
    /// 
    /// </summary>
    public string ServiceNames { get; } = servicesBuilder.ServiceNames;

    /// <summary>
    /// 
    /// </summary>
    public string BusinessLogic { get; } = commandResult.BusinessLogicFullyQualifiedName;

    /// <summary>
    /// 
    /// </summary>
    public string BusinessLogicDelegateName { get; } = commandResult.BusinessLogicDelegateName;

    /// <summary>
    /// 
    /// </summary>
    public string BusinessLogicDelegateParameters { get; } = BuildDelegateParameters(commandResult.BusinessLogicParameters,
                                                                                     commandResult.Services,
                                                                                     commandResult.KeyedServices,
                                                                                     commandResult.ModelIdUnderlyingPropertyType ?? commandResult.ModelIdPropertyType);

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Build() =>
$@"using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalApiGen.Framework.Mapping;
using System.Net.Mime;

using {ModelName} = {ModelFullyQualifiedName};

namespace {ClassNamespace};

/// <summary>
/// 
/// </summary>
#nullable enable
public partial class {ClassName}
{{
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""endpointRouteBuilder""></param>
    public virtual RouteHandlerBuilder MapDeleteV{ApiVersion}(IEndpointRouteBuilder endpointRouteBuilder)
    {{
        return endpointRouteBuilder.MapDelete
        (
            ""/{ModelPluralNameLower}/{{id}}"",
            async Task<Results<NoContent, BadRequest>>
            (
                CancellationToken cancellationToken,
                [FromRoute] {ModelIdUnderlyingPropertyType ?? ModelIdPropertyType} id,
                [FromServices] {BusinessLogic} businessLogic
            ) =>
            {{
                ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                await businessLogic.{BusinessLogicDelegateName}({BusinessLogicDelegateParameters}).ConfigureAwait(false);
                return TypedResults.NoContent();
            }}
        )
        .WithName(""{RouteNameFactory.Delete(ModelPluralName, ApiVersion)}"")
        .WithTags(""{ModelPluralNameLower}"")
        .WithOpenApi(operation => new(operation) {{ Summary = ""Deletes {ModelName.WithIndefiniteArticle()} via the id."" }})
        .MapToApiVersion({ApiVersion})
        .Produces(StatusCodes.Status204NoContent)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json);
     }}
}}";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessLogicParameters"></param>
    /// <param name="services"></param>
    /// <param name="keyedServices"></param>
    /// <param name="modelIdPropertyType"></param>
    /// <returns></returns>
    private static string BuildDelegateParameters(EquatableArray<BusinessLogicParamterResult> businessLogicParameters,
                                                  EquatableArray<string> services,
                                                  EquatableDictionary<string, string> keyedServices,
                                                  string modelIdPropertyType)
    {
        ReadOnlySpan<string> keys = keyedServices.KeysAsSpan();
        ReadOnlySpan<string> values = keyedServices.ValuesAsSpan();
        ReadOnlySpan<string> businessLogicParametersSpan = businessLogicParameters.Select(param => param.Type).ToArray();
        StringBuilder stringBuilder = new();

        foreach (string parameter in businessLogicParametersSpan)
        {
            if (services.Contains(parameter))
            {
                string serviceName = parameter.Split('.').Last();
                string serviceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(serviceName);
                stringBuilder.Append(serviceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (values.IndexOf(parameter) is int index && index != -1)
            {
                string keyedServiceNameCamelCase = JsonNamingPolicy.CamelCase.ConvertName(keys[index]);
                stringBuilder.Append(keyedServiceNameCamelCase);
                stringBuilder.Append(", ");
            }
            else if (parameter == modelIdPropertyType)
            {
                stringBuilder.Append("id, ");
            }
            else if (parameter == typeof(CancellationToken).FullName)
            {
                stringBuilder.Append("cancellationToken, ");
            }
        }

        stringBuilder.Length -= 2;
        string delegateParameters = stringBuilder.ToString();
        return delegateParameters;
    }

    #endregion
}