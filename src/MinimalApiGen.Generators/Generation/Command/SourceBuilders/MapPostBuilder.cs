using MinimalApiGen.Generators.Generation.Command.Results;
using MinimalApiGen.Generators.Generation.Shared;
using MinimalApiGen.Generators.Generation.Shared.Results;
using MinimalApiGen.Generators.Generation.Shared.SourceBuilders;
using System;
using System.Text;

namespace MinimalApiGen.Generators.Generation.Command.SourceBuilders;

/// <summary>
/// 
/// </summary>
/// <param name="commandResult"></param>
/// <param name="servicesBuilder"></param>
internal sealed class MapPostBuilder(ICommandResult commandResult, ServicesBuilder servicesBuilder)
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
    public string? ModelIdPropertyNullCheck { get; } = BuildModelIdPropertyNullCheck(commandResult.ModelIdUnderlyingPropertyType);

    /// <summary>
    /// 
    /// </summary>
    public string ResponseName { get; } = !string.IsNullOrWhiteSpace(commandResult.ResponseName) ? commandResult.ResponseName! : throw new ArgumentNullException(nameof(IResult.ResponseName));

    /// <summary>
    /// 
    /// </summary>
    public string ResponseFullyQualifiedName { get; } = !string.IsNullOrWhiteSpace(commandResult.ResponseFullyQualifiedName) ? commandResult.ResponseFullyQualifiedName! : throw new ArgumentNullException(nameof(IResult.ResponseFullyQualifiedName));

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
    public string BusinessLogicDelegateParameters { get; } = DelegateParametersBuilder.BuildForModel(commandResult.BusinessLogicParameters,
                                                                                                     commandResult.Services,
                                                                                                     commandResult.KeyedServices,
                                                                                                     commandResult.ModelFullyQualifiedName);

    /// <summary>
    /// 
    /// </summary>
    public string FluentValidationService => commandResult.WithFluentValidation ? BuildFluentValidationService() : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string FluentValidationCall => commandResult.WithFluentValidation ? BuildFluentValidationCall() : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string FluentValidationResult => commandResult.WithFluentValidation ? ", ValidationProblem" : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string FluentValidatorNullCheck => commandResult.WithFluentValidation ? BuildFluentValidationNullCheck() : string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string JwtAuthentication { get; } = commandResult.WithJwtAuthentication ? JwtAuthenticationBuilder.Build() : string.Empty;

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
using {RequestName} = {RequestFullyQualifiedName};
using {ResponseName} = {ResponseFullyQualifiedName};

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
    public virtual RouteHandlerBuilder MapPostV{ApiVersion}(IEndpointRouteBuilder endpointRouteBuilder)
    {{
        return endpointRouteBuilder.MapPost
        (
            ""/{ModelPluralNameLower}"",
            async Task<Results<CreatedAtRoute<{ResponseName}>, BadRequest{FluentValidationResult}>>
            (
                CancellationToken cancellationToken,
                [FromBody] {RequestName} request,{FluentValidationService}
                [FromServices] {BusinessLogic} businessLogic,
                [FromServices] IMappingService<{RequestName}, {ModelName}> requestMappingService,
                [FromServices] IMappingService<{ModelName}, {ResponseName}> responseMappingService{FromServices}{FromKeyedServices}
            ) =>
            {{
                {FluentValidatorNullCheck}ArgumentNullException.ThrowIfNull(businessLogic, nameof(businessLogic));
                ArgumentNullException.ThrowIfNull(requestMappingService, nameof(requestMappingService));
                ArgumentNullException.ThrowIfNull(responseMappingService, nameof(responseMappingService));
                {FluentValidationCall}
                {ModelName} model = requestMappingService.Map(request);
                {ModelName}? insertedModel = await businessLogic.{BusinessLogicDelegateName}({BusinessLogicDelegateParameters}).ConfigureAwait(false);

                if (insertedModel is null)
                {{
                    return TypedResults.BadRequest();
                }}

                {ResponseName} response = responseMappingService.Map(insertedModel);
                string routeName = ""{RouteNameFactory.GetById(ModelPluralName, ApiVersion)}"";
                {ModelIdPropertyType} newId = insertedModel.{ModelIdPropertyName}{ModelIdPropertyNullCheck};
                return TypedResults.CreatedAtRoute<{ResponseName}>(response, routeName, new {{id = newId}});
            }}
        )
        .WithName(""{RouteNameFactory.Post(ModelPluralName, ApiVersion)}"")
        .WithTags(""{ModelPluralNameLower}"")
        .WithOpenApi(operation => new(operation) {{ Summary = ""Posts {ModelName.WithIndefiniteArticle()} via {RequestName.WithIndefiniteArticle()}, mapped to {ResponseName.WithIndefiniteArticle()} response."" }})
        .MapToApiVersion({ApiVersion})
        .Accepts<{RequestName}>(MediaTypeNames.Application.Json)
        .Produces<{ResponseName}>(StatusCodes.Status201Created, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status400BadRequest, MediaTypeNames.Application.Json)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError, MediaTypeNames.Application.Json){JwtAuthentication};
     }}
}}";

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="underlyingType"></param>
    /// <returns></returns>
    private static string BuildModelIdPropertyNullCheck(string? underlyingType) => string.IsNullOrEmpty(underlyingType) ? string.Empty : $" ?? throw new {nameof(NullReferenceException)}()";

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private string BuildFluentValidationService()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine();
        stringBuilder.Append("\t\t\t\t[FromServices] FluentValidation.IValidator");
        stringBuilder.Append("<");
        stringBuilder.Append(RequestName);
        stringBuilder.Append("> validator,");
        string result = stringBuilder.ToString();
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static string BuildFluentValidationCall()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("\t\t\t\tFluentValidation.Results.ValidationResult validationResult = await validator.ValidateAsync(request).ConfigureAwait(false);");
        stringBuilder.AppendLine("\t\t\t\tif (!validationResult.IsValid)");
        stringBuilder.AppendLine("\t\t\t\t{");
        stringBuilder.AppendLine("\t\t\t\t\treturn TypedResults.ValidationProblem(validationResult.ToDictionary());");
        stringBuilder.AppendLine("\t\t\t\t}");
        string result = stringBuilder.ToString();
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static string BuildFluentValidationNullCheck()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.AppendLine("ArgumentNullException.ThrowIfNull(validator, nameof(validator));");
        stringBuilder.Append("\t\t\t\t");
        string result = stringBuilder.ToString();
        return result;
    }

    #endregion
}