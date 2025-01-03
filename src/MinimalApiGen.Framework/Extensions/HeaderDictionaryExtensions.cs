using Microsoft.AspNetCore.Http;

namespace MinimalApiGen.Framework.Extensions;

/// <summary>
/// 
/// </summary>
public static class HeaderDictionaryExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="headers"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void AppendSanitised(this IHeaderDictionary headers, string key, int value)
    {
        string sanitisedValue = value.ToString();
        headers.Append(key, sanitisedValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="headers"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void AppendSanitised(this IHeaderDictionary headers, string key, bool value)
    {
        string sanitisedValue = value.ToString().ToLower();
        headers.Append(key, sanitisedValue);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="headers"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void AppendSanitised(this IHeaderDictionary headers, string key, string value)
    {
        string sanitisedValue = value
                                .Replace("\r", string.Empty)
                                .Replace("%0d", string.Empty)
                                .Replace("%0D", string.Empty)
                                .Replace("\n", string.Empty)
                                .Replace("%0a", string.Empty)
                                .Replace("%0A", string.Empty);
        headers.Append(key, sanitisedValue);
    }

    #endregion
}