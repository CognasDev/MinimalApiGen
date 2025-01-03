using MinimalApiGen.Generators.Abstractions.Get;
using System;

namespace MinimalApiGen.Generators.Abstractions.Common;

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
    IWithGetWithCache CachedFor(TimeSpan timeSpan);

    #endregion
}