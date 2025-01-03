﻿using MinimalApiGen.Generators.Abstractions.Common;

namespace MinimalApiGen.Generators.Abstractions.Query;

/// <summary>
/// 
/// </summary>
public interface IQueryWithResponse : ICache, IMapping, IPagination, IVersion, IQuery
{
}