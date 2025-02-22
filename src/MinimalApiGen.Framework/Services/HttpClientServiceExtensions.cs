using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiGen.Framework.Services;

/// <summary>
/// 
/// </summary>
public static class HttpClientServiceExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddHttpClientServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient();
        serviceCollection.AddSingleton<IHttpClientService, HttpClientService>();
    }

    #endregion
}