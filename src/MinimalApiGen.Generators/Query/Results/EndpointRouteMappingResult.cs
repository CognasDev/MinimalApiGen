﻿using MinimalApiGen.Generators.Query.Generation;

namespace MinimalApiGen.Generators.Query.Results;

/// <summary>
/// 
/// </summary>
/// <param name="ClassNamespace"></param>
/// <param name="ClassName"></param>
/// <param name="Version"></param>
/// <param name="QueryType"></param>
internal readonly record struct EndpointRouteMappingResult(string ClassNamespace, string ClassName, int Version, QueryType QueryType);