using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace Samples.MusicCollection.Web.Components.Pages;

/// <summary>
/// 
/// </summary>
public sealed partial class Error
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    [CascadingParameter]
    private HttpContext? HttpContext { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private string? RequestId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    private bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

    #endregion

    #region Protected Method Declarations

    /// <summary>
    /// 
    /// </summary>
    protected override void OnInitialized() => RequestId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;

    #endregion
}