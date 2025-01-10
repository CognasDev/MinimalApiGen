using MinimalApiGen.Generators.Abstractions.Query;
using MinimalApiGen.Generators.Abstractions.Query.Get;
using MinimalApiGen.Generators.Abstractions.Query.GetById;
using MinimalApiGen.Generators.Abstractions.Query.Shared;

namespace MinimalApiGen.Generators.Generation.Query.Fluent;

/// <summary>
/// 
/// </summary>
internal static class FullyQualifiedMethodNames
{
    #region Field Declarations

    /// <summary>
    /// 
    /// </summary>
    public const string Query = "MinimalApiGen.Framework.Generation.ApiGeneration.Query<TModel>()";

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public static string WithGet { get; } = $"{typeof(IQueryOperations).FullName}.{nameof(IQueryOperations.WithGet)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetById { get; } = $"{typeof(IQueryOperations).FullName}.{nameof(IQueryOperations.WithGetById)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithNamespace { get; } = $"{typeof(IQueryRoot).FullName}.{nameof(IQueryRoot.WithNamespace)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithNamespaceOf { get; } = $"{typeof(IQueryRoot).FullName}.{nameof(IQueryRoot.WithNamespaceOf)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithVersion { get; } = $"{typeof(IVersion).FullName}.{nameof(IVersion.WithVersion)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetServices { get; } = $"{typeof(IGetServices).FullName}.{nameof(IGetServices.WithServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetByIdServices { get; } = $"{typeof(IGetByIdServices).FullName}.{nameof(IGetByIdServices.WithServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetKeyedServices { get; } = $"{typeof(IGetKeyedServices).FullName}.{nameof(IGetKeyedServices.WithKeyedServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetByIdKeyedServices { get; } = $"{typeof(IGetByIdKeyedServices).FullName}.{nameof(IGetByIdKeyedServices.WithKeyedServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPagination { get; } = $"{typeof(IWithGetWithResponse).FullName}.{nameof(IWithGetWithResponse.WithPagination)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetBusinessLogic { get; } = $"{typeof(IWithGetOperation).FullName}.{nameof(IWithGetOperation.WithBusinessLogic)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetByIdBusinessLogic { get; } = $"{typeof(IWithGetByIdOperation).FullName}.{nameof(IWithGetByIdOperation.WithBusinessLogic)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithMappingService { get; } = $"{typeof(IMappingService).FullName}.{nameof(IMappingService.WithMappingService)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetResponse { get; } = $"{typeof(IGetResponse).FullName}.{nameof(IGetResponse.WithResponse)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetByIdResponse { get; } = $"{typeof(IGetByIdResponse).FullName}.{nameof(IGetByIdResponse.WithResponse)}";

    /// <summary>
    /// 
    /// </summary>
    public static string CachedFor { get; } = $"{typeof(ICache).FullName}.{nameof(ICache.CachedFor)}";

    #endregion
}