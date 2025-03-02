﻿using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;

namespace MinimalApiGen.Framework.Extensions;

/// <summary>
/// 
/// </summary>
public static class WebApplicationExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    public static void UseMinimalApiFramework(this WebApplication webApplication)
    {
        webApplication.UseOutputCache();
        webApplication.MapHealthChecks("/api/health", new()
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }

    #endregion
}