using MinimalApiGen.Framework.Generation.Command;
using MinimalApiGen.Framework.Generation.Query;
using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class ApiGeneration
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <returns></returns>
    public static ICommandRoot<TModel> Command<TModel>() => new CommandRoot<TModel>();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <returns></returns>
    public static IQueryRoot<TModel> Query<TModel>() => new QueryRoot<TModel>();

    #endregion
}