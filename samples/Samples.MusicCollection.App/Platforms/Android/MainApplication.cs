using Android.App;
using Android.Runtime;

namespace Samples.MusicCollection.App;

/// <summary>
/// 
/// </summary>
#if DEBUG
[Application(UsesCleartextTraffic = true)]
#else
[Application]
#endif
public sealed class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}