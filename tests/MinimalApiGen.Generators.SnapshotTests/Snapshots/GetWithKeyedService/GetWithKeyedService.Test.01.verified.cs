﻿//HintName: EndpointRouteMappingExtension.Query.g.cs
using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Versioning;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class EndpointRouteMappingExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseMinimalApiGenEndpointRouteMaps(this WebApplication webApplication)
    {
		MinimalApiGen.Generators.SnapshotTests.Fixtures.SampleModelQueryRouteEndpointsMapper mapperV1 = new();
		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);
		mapperV1.MapGetV1(apiVersionRouteV1);

    }
}
