using System;

namespace MinimalApiGen.Generators.Abstractions.Query.Shared;

/// <summary>
/// 
/// </summary>
public interface ICache
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="timeSpan"></param>
    /// <returns></returns>
    IQueryWithCache CachedFor(TimeSpan timeSpan);

    #endregion
}