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
    public static string GetIndefiniteArticle(this string input)
    {
        char firstChar = input.ToLowerInvariant()[0];
        bool vowelStart = "aeiou".IndexOf(firstChar) >= 0;
        return vowelStart ? "an" : "a";
    }

    #endregion
}