using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Post;
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

    #endregion

    #region Property Declarations - Post

    /// <summary>
    /// 
    /// </summary>
    public static string WithPost { get; } = $"{typeof(ICommandOperations).FullName}.{nameof(ICommandOperations.WithPost)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostBusinessLogic { get; } = $"{typeof(IWithPostOperation).FullName}.{nameof(IWithPostOperation.WithBusinessLogic)}";

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
    public static string WithRequestMappingService { get; } = $"{typeof(IRequestMappingService).FullName}.{nameof(IRequestMappingService.WithRequestMappingService)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPostResponse { get; } = $"{typeof(IPostResponse).FullName}.{nameof(IPostResponse.WithResponse)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithResponseMappingService { get; } = $"{typeof(IResponseMappingService).FullName}.{nameof(IResponseMappingService.WithResponseMappingService)}";

    #endregion

    #region Property Declarations - Put
    #endregion

    #region Property Declarations - Delete
    #endregion
}