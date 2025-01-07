using MinimalApiGen.Generators.Abstractions.Query;
using MinimalApiGen.Generators.Abstractions.Query.Common;
using MinimalApiGen.Generators.Abstractions.Query.Get;

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
    public static string WithServices { get; } = $"{typeof(IServices).FullName}.{nameof(IServices.WithServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithKeyedServices { get; } = $"{typeof(IKeyedServices).FullName}.{nameof(IKeyedServices.WithKeyedServices)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithPagination { get; } = $"{typeof(IWithGetWithResponse).FullName}.{nameof(IWithGetWithResponse.WithPagination)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithBusinessLogic { get; } = $"{typeof(IWithGet).FullName}.{nameof(IWithGet.WithBusinessLogic)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithMappingService { get; } = $"{typeof(IMappingService).FullName}.{nameof(IMappingService.WithMappingService)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithResponse { get; } = $"{typeof(IResponse).FullName}.{nameof(IResponse.WithResponse)}";

    /// <summary>
    /// 
    /// </summary>
    public static string CachedFor { get; } = $"{typeof(ICache).FullName}.{nameof(ICache.CachedFor)}";

    #endregion
}