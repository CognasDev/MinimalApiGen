﻿using MinimalApiGen.Framework.Generation.Command;
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
    public static ICommandRoot Command<TModel>() => new CommandRoot();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <returns></returns>
    public static IQueryRoot Query<TModel>() => new QueryRoot();

    #endregion
}