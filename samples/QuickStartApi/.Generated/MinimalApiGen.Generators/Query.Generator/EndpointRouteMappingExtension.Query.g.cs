﻿using Microsoft.AspNetCore.Builder;
using MinimalApiGen.Framework.Versioning;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static partial class EndpointRouteMappingExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseQueryRouteMaps(this WebApplication webApplication)
    {
		QuickStartApi.V1.Query.SampleModelQueryRouteEndpointsMapper mapperV1 = new();

		RouteGroupBuilder apiVersionRouteV1 = webApplication.GetApiVersionRoute(1);

		mapperV1.MapGetV1(apiVersionRouteV1);
		mapperV1.MapGetByIdV1(apiVersionRouteV1);

    }
}