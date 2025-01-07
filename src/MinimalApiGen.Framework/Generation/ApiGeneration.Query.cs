using MinimalApiGen.Framework.Generation.Query;
using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static partial class ApiGeneration
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <returns></returns>
    public static IQueryRoot Query<TModel>() => new QueryRoot();

    #endregion
}