using System;
using System.Text.RegularExpressions;

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
    /// <exception cref="ArgumentNullException"></exception>
    public static string WithIndefiniteArticle(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException($"{nameof(input)} cannot be null or whitespace.", nameof(input));
        }

        ReadOnlySpan<char> word = input.Trim().ToLowerInvariant().AsSpan();
        if (word.IsEmpty)
        {
            return $"an {input}";
        }

        if (StartsWithAny(word, "euler", "heir", "honest", "hono") ||  (word.StartsWith("hour".AsSpan()) && !word.StartsWith("houri".AsSpan())))
        {
            return $"an {input}";
        }

        if (word.Length == 1 && "aedhilnorsx".AsSpan().IndexOf(word[0]) >= 0)
        {
            return $"an {input}";
        }

        if (Regex.IsMatch(input, @"^(?!FJO|[HLMNS]Y.|RY[EO]|SQU|(F[LR]?|[HL]|MN?|N|RH?|S[CHKLMNPTVW]?|X(YL)?)[AEIOU])[FHLMNRSX][A-Z]"))
        {
            return $"an {input}";
        }

        if (Regex.IsMatch(input, @"^e[uw]|^onc?e\b|^uni([^nmd]|mo)|^u[bcfhjkqrst][aeiou]"))
        {
            return $"a {input}";
        }

        if (Regex.IsMatch(input, @"^U[NK][AIEO]"))
        {
            return $"a {input}";
        }

        if (input == input.ToUpper() && "aedhilnorsx".AsSpan().IndexOf(word[0]) >= 0)
        {
            return $"an {input}";
        }

        if ("aeiou".AsSpan().IndexOf(word[0]) >= 0)
        {
            return $"an {input}";
        }

        if (Regex.IsMatch(input, @"^y(b[lor]|cl[ea]|fere|gg|p[ios]|rou|tt)"))
        {
            return $"an {input}";
        }

        return $"a {input}";
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <param name="prefixes"></param>
    /// <returns></returns>
    private static bool StartsWithAny(ReadOnlySpan<char> word, params string[] prefixes)
    {
        foreach (string prefix in prefixes)
        {
            if (word.StartsWith(prefix.AsSpan()))
            {
                return true;
            }
        }
        return false;
    }

    #endregion
}