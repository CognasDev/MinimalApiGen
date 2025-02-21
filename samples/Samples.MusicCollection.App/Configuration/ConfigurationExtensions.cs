using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Samples.MusicCollection.App.Configuration;

/// <summary>
/// 
/// </summary>
public static class ConfigurationExtensions
{
    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mauiAppBuilder"></param>
    /// <exception cref="NullReferenceException"></exception>
    public static void AddJsonConfiguration(this MauiAppBuilder mauiAppBuilder)
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        using Stream resourceStream = executingAssembly.GetManifestResourceStream("Samples.MusicCollection.App.appsettings.json") ?? throw new NullReferenceException("appsettings.json");
        IConfigurationRoot appSettings = new ConfigurationBuilder().AddJsonStream(resourceStream).Build();
        mauiAppBuilder.Configuration.AddConfiguration(appSettings);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBind"></typeparam>
    /// <param name="mauiAppBuilder"></param>
    public static void BindConfigurationSection<TBind>(this MauiAppBuilder mauiAppBuilder) where TBind : class
        => mauiAppBuilder.Services.Configure<TBind>(mauiAppBuilder.Configuration.GetSection(typeof(TBind).Name));

    #endregion
}