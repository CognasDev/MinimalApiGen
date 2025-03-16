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
            throw new ArgumentNullException(nameof(input));
        }

        Match match = Regex.Match(input, @"\w+");
        if (!match.Success)
        {
            return $"an {input}";
        }

        string word = match.Groups[0].Value;
        string wordLower = word.ToLower();

        foreach (string anword in new string[] { "euler", "heir", "honest", "hono" })
        {
            if (wordLower.StartsWith(anword))
            {
                return $"an {input}";
            }
        }

        if (wordLower.StartsWith("hour") && !wordLower.StartsWith("houri"))
        {
            return $"an {input}";
        }

        if (wordLower.StartsWith("one ") || wordLower.StartsWith("one-"))
        {
            return $"a {input}";
        }

        char[] charList = ['a', 'e', 'd', 'h', 'i', 'l', 'm', 'n', 'o', 'r', 's', 'x'];
        if (wordLower.Length == 1)
        {
            return wordLower.IndexOfAny(charList) == 0 ? $"an {input}" : $"a {input}";
        }

        if (Regex.Match(word, "(?!FJO|[HLMNS]Y.|RY[EO]|SQU|(F[LR]?|[HL]|MN?|N|RH?|S[CHKLMNPTVW]?|X(YL)?)[AEIOU])[FHLMNRSX][A-Z]").Success)
        {
            return $"an {input}";
        }

        foreach (string regex in new string[] { "^e[uw]", "^onc?e\b", "^uni([^nmd]|mo)", "^u[bcfhjkqrst][aeiou]" })
        {
            if (Regex.IsMatch(wordLower, regex))
            {
                return $"a {input}";
            }
        }

        if (Regex.IsMatch(word, "^U[NK][AIEO]"))
        {
            return $"a {input}";
        }

        if (word == word.ToUpper())
        {
            return wordLower.IndexOfAny(charList) == 0 ? $"an {input}" : $"a {input}";
        }

        if (wordLower.IndexOfAny(['a', 'e', 'i', 'o', 'u']) == 0 || Regex.IsMatch(wordLower, "^y(b[lor]|cl[ea]|fere|gg|p[ios]|rou|tt)"))
        {
            return $"an {input}";
        }

        return $"a {input}";
    }


    #endregion
}