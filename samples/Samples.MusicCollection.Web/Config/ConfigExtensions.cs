namespace Samples.MusicCollection.Web.Config;

/// <summary>
/// 
/// </summary>
public static class ConfigExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    /// <param name="webApplicationBuilder"></param>
    public static void BindConfigSection<TConfig>(this WebApplicationBuilder webApplicationBuilder) where TConfig : class
    {
        IConfigurationSection configurationSection = webApplicationBuilder.Configuration.GetSection(typeof(TConfig).Name);
        webApplicationBuilder.Services.Configure<TConfig>(configurationSection);
    }

    #endregion
}