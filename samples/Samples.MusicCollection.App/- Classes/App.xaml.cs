namespace Samples.MusicCollection.App;

/// <summary>
/// 
/// </summary>
public sealed partial class App : Application
{
    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="App"/>
    /// </summary>
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }

    #endregion
}