using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Delete;
using MinimalApiGen.Generators.Abstractions.Command.Post;
using MinimalApiGen.Generators.Abstractions.Command.Put;
using MinimalApiGen.Generators.Abstractions.Command.Shared;

namespace MinimalApiGen.Generators.Generation.Command.Fluent;

/// <summary>
/// 
/// </summary>
internal static class CommandMethodNames
{
    #region Field Declarations

    /// <summary>
    /// 
    /// </summary>
    public const string Command = "MinimalApiGen.Framework.Generation.ApiGeneration.Command<TModel>()";

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public static string WithNamespace { get; } = $"{typeof(ICommandRoot<>).Namespace}.{typeof(ICommandRoot<>).Name.Split('`')[0]}.{nameof(ICommandRoot<object>.WithNamespace)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithNamespaceOf { get; } = $"{typeof(ICommandRoot<>).Namespace}.{typeof(ICommandRoot<>).Name.Split('`')[0]}.{nameof(ICommandRoot<object>.WithNamespaceOf)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithVersion { get; } = $"{typeof(IVersion).FullName}.{nameof(IVersion.WithVersion)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithModelId { get; } = $"{typeof(ICommandWithModelId<>).Namespace}.{typeof(ICommandWithModelId<>).Name.Split('`')[0]}.{nameof(ICommandWithModelId<object>.WithModelId)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithRequestMappingService { get; } = $"{typeof(IRequestMappingService).FullName}.{nameof(IRequestMappingService.WithRequestMappingService)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithResponseMappingService { get; } = $"{typeof(IResponseMappingService).FullName}.{nameof(IResponseMappingService.WithResponseMappingService)}";

    #endregion

    #region Property Declarations - Post

    /// <summary>
    /// 
    /// </summary>
    public static string WithPost { get; } = $"{typeof(ICommandOperations).FullName}.{nameof(ICommandOperations.WithPost)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostHandler { get; } = $"{typeof(IWithPostOperation).FullName}.{nameof(IWithPostOperation.WithHandler)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostServices { get; } = $"{typeof(IPostServices).FullName}.{nameof(IPostServices.WithServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostKeyedServices { get; } = $"{typeof(IPostKeyedServices).FullName}.{nameof(IPostKeyedServices.WithKeyedServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostRequest { get; } = $"{typeof(IPostRequest).FullName}.{nameof(IPostRequest.WithRequest)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostResponse { get; } = $"{typeof(IPostResponse).FullName}.{nameof(IPostResponse.WithResponse)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostFluentValidation { get; } = $"{typeof(IPostFluentValidation).FullName}.{nameof(IPostFluentValidation.WithFluentValidation)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostJwtAuthentication { get; } = $"{typeof(IPostJwtAuthentication).FullName}.{nameof(IPostJwtAuthentication.WithJwtAuthentication)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostAddEndpontFilter { get; } = $"{typeof(IPostAddEndpointFilter).FullName}.{nameof(IPostAddEndpointFilter.WithAddEndpointFilter)}";

    #endregion

    #region Property Declarations - Put

    /// <summary>
    /// 
    /// </summary>
    public static string WithPut { get; } = $"{typeof(ICommandOperations).FullName}.{nameof(ICommandOperations.WithPut)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutHandler { get; } = $"{typeof(IWithPutOperation).FullName}.{nameof(IWithPutOperation.WithHandler)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutServices { get; } = $"{typeof(IPutServices).FullName}.{nameof(IPutServices.WithServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutKeyedServices { get; } = $"{typeof(IPutKeyedServices).FullName}.{nameof(IPutKeyedServices.WithKeyedServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutRequest { get; } = $"{typeof(IPutRequest).FullName}.{nameof(IPutRequest.WithRequest)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutResponse { get; } = $"{typeof(IPutResponse).FullName}.{nameof(IPutResponse.WithResponse)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutFluentValidation { get; } = $"{typeof(IPutFluentValidation).FullName}.{nameof(IPutFluentValidation.WithFluentValidation)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutJwtAuthentication { get; } = $"{typeof(IPutJwtAuthentication).FullName}.{nameof(IPutJwtAuthentication.WithJwtAuthentication)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPutAddEndpontFilter { get; } = $"{typeof(IPutAddEndpointFilter).FullName}.{nameof(IPutAddEndpointFilter.WithAddEndpointFilter)}";

    #endregion

    #region Property Declarations - Delete

    /// <summary>
    /// 
    /// </summary>
    public static string WithDelete { get; } = $"{typeof(ICommandOperations).FullName}.{nameof(ICommandOperations.WithDelete)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithDeleteHandler { get; } = $"{typeof(IWithDeleteOperation).FullName}.{nameof(IWithDeleteOperation.WithHandler)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithDeleteServices { get; } = $"{typeof(IDeleteServices).FullName}.{nameof(IDeleteServices.WithServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithDeleteKeyedServices { get; } = $"{typeof(IDeleteKeyedServices).FullName}.{nameof(IDeleteKeyedServices.WithKeyedServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithDeleteJwtAuthentication { get; } = $"{typeof(IDeleteJwtAuthentication).FullName}.{nameof(IDeleteJwtAuthentication.WithJwtAuthentication)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithDeleteAddEndpontFilter { get; } = $"{typeof(IDeleteAddEndpointFilter).FullName}.{nameof(IDeleteAddEndpointFilter.WithAddEndpointFilter)}";

    #endregion
}