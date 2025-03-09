using MinimalApiGen.Framework.Pluralize.Rules;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MinimalApiGen.Framework.Pluralize;

/// <summary>
/// 
/// </summary>
internal sealed class Pluralizer : IPluralizer
{
    #region Field Declarations

    private static readonly Lazy<IPluralizer> _instance = new(() => new Pluralizer());
    private static readonly ReplaceRule[] _pluralRules = PluralRules.GetRules();
    private static readonly ICollection<string> _noPlurals = NoPlurals.GetNoPlurals();
    private static readonly IDictionary<string, string> _irregularPlurals = IrregularRules.GetIrregularPlurals();
    private static readonly IDictionary<string, string> _irregularSingles = IrregularRules.GetIrregularSingulars();
    private static readonly Regex _replacementRegex = new("\\$(\\d{1,2})", RegexOptions.Compiled);

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public static IPluralizer Instance => _instance.Value;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    private Pluralizer()
    {
    }

    #endregion
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public string Pluralize(string word)
    {
        if (_irregularPlurals.ContainsKey(word))
        {
            return word;
        }
        if (_irregularSingles.TryGetValue(word, out string? token))
        {
            return RestoreCase(word, token);
        }
        return ApplyRules(word, word);
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="originalWord"></param>
    /// <param name="newWord"></param>
    /// <returns></returns>
    private string RestoreCase(string originalWord, string newWord)
    {
        if (originalWord == newWord)
        {
            return newWord;
        }
        return originalWord switch
        {
            _ when originalWord == originalWord.ToLower() => newWord.ToLower(),
            _ when originalWord == originalWord.ToUpper() => newWord.ToUpper(),
            _ when originalWord[0] == char.ToUpper(originalWord[0]) => char.ToUpper(newWord[0]) + newWord.Substring(1),
            _ => newWord.ToLower()
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <param name="originalWord"></param>
    /// <returns></returns>
    private string ApplyRules(string token, string originalWord)
    {
        if (string.IsNullOrEmpty(token) || _noPlurals.Contains(token))
        {
            return originalWord;
        }

        ReadOnlySpan<ReplaceRule> span = _pluralRules;

        int length = span.Length - 1;
        for (int index = length; index >= 0; index--)
        {
            ReplaceRule rule = span[index];
            Regex regex = rule.Condition;
            if (regex.IsMatch(originalWord))
            {
                Match match = regex.Match(originalWord);
                string matchString = match.Groups[0].Value;
                if (string.IsNullOrWhiteSpace(matchString))
                {
                    return regex.Replace(originalWord, GetReplaceMethod(originalWord[match.Index - 1].ToString(), rule.ReplaceWith), 1);
                }

                return regex.Replace(originalWord, GetReplaceMethod(matchString, rule.ReplaceWith), 1);
            }
        }

        return originalWord;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="originalWord"></param>
    /// <param name="replacement"></param>
    /// <returns></returns>
    private MatchEvaluator GetReplaceMethod(string originalWord, string replacement)
    {
        return match =>
        {
            return RestoreCase(originalWord, _replacementRegex.Replace(replacement, m => match.Groups[int.Parse(m.Groups[1].Value)].Value));
        };
    }

    #endregion
}