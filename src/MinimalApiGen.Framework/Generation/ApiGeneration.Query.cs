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
    public static IQuery Query<TModel>() => new Query();

    #endregion
}