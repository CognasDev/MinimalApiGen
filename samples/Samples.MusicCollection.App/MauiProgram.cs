using Cognas.MauiTools.Shared.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Samples.MusicCollection.App.Albums;
using Samples.MusicCollection.App.Artists;
using Samples.MusicCollection.App.Configuration;
using Samples.MusicCollection.App.Navigation;

namespace Samples.MusicCollection.App;

/// <summary>
/// 
/// </summary>
public static class MauiProgram
{
    #region Static Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder mauiAppBuilder = MauiApp.CreateBuilder();
        mauiAppBuilder.Services.AddHttpClient();
        mauiAppBuilder.AddJsonConfiguration();
        mauiAppBuilder.BindConfigurationSection<BaseAddresses>();
        mauiAppBuilder.BindConfigurationSection<MicroserviceUris>();
        mauiAppBuilder.UseMauiApp<App>()
                      .UseMauiCommunityToolkit()
                      .ConfigureFonts(fonts =>
                      {
                          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                      });

        mauiAppBuilder.Services.AddSingleton<AlbumsView>();
        mauiAppBuilder.Services.AddSingleton<AlbumsViewModel>();
        mauiAppBuilder.Services.AddSingleton<ArtistViewModel>();
        mauiAppBuilder.Services.AddSingleton<ArtistView>();
        mauiAppBuilder.Services.AddSingleton<ArtistsViewModel>();
        mauiAppBuilder.Services.AddSingleton<ArtistsView>();
        mauiAppBuilder.Services.AddSingleton<IAlbumsRepository, AlbumsRepository>();
        mauiAppBuilder.Services.AddSingleton<IArtistsRepository, ArtistsRepository>();
        mauiAppBuilder.Services.AddSingleton<IHttpClientService, HttpClientService>();
        mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();

#if DEBUG
        mauiAppBuilder.Logging.AddDebug();
#endif

        MauiApp mauiApp = mauiAppBuilder.Build();
        INavigationService navigationService = mauiApp.Services.GetService<INavigationService>() ?? throw new NullReferenceException(nameof(INavigationService));
        navigationService.RegisterRoutes();

        return mauiApp;
    }

    #endregion
}