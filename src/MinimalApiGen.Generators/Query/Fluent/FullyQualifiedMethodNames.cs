using MinimalApiGen.Generators.Abstractions.Common;
using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Generators.Query.Fluent;

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
    public static string WithGet { get; } = $"{typeof(IQuery).FullName}.{nameof(IQuery.WithGet)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithGetById { get; } = $"{typeof(IQuery).FullName}.{nameof(IQuery.WithGetById)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithNamespace { get; } = $"{typeof(INamespace).FullName}.{nameof(INamespace.WithNamespace)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithNamespaceOf { get; } = $"{typeof(INamespaceOf).FullName}.{nameof(INamespaceOf.WithNamespaceOf)}";

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
    public static string WithPagination { get; } = $"{typeof(IPagination).FullName}.{nameof(IPagination.WithPagination)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithBusinessLogic { get; } = $"{typeof(IBusinessLogic).FullName}.{nameof(IBusinessLogic.WithBusinessLogic)}";

    /// <summary>
    /// 
    /// </summary>
    public static string WithMappingService { get; } = $"{typeof(IMapping).FullName}.{nameof(IMapping.WithMappingService)}";

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