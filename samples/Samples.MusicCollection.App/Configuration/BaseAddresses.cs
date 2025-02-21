namespace Samples.MusicCollection.App.Configuration;

/// <summary>
/// 
/// </summary>
public sealed record BaseAddresses
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Android { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public string Ios { get; set; } = null!;

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="BaseAddresses"/>
    /// </summary>
    public BaseAddresses()
    {
    }

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetBaseAddress() => DeviceInfo.Platform == DevicePlatform.Android ? Android : Ios;

    #endregion
}