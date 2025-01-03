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
    public static void UseMinimalApiGenFramework(this WebApplication webApplication)
    {
        webApplication.UseOutputCache();
    }

    #endregion
}