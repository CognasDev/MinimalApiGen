using System;

namespace MinimalApiGen.Generators.Generation.Shared;

/// <summary>
/// 
/// </summary>
internal static class StringExtensions
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string WithIndefiniteArticle(this string input)
    {
        char firstChar = input.ToLowerInvariant().AsSpan()[0];
        bool vowelStart = "aeiou".IndexOf(firstChar) >= 0;
        string indefiniteArticle = vowelStart ? "an" : "a";
        string result = $"{indefiniteArticle} {input}";
        return result;
    }

    #endregion
}