using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimalApiGen.Framework.Pluralize.Rules;

/// <summary>
/// 
/// </summary>
internal static class IrregularRules
{
    #region Field Declarations

    private static readonly Dictionary<string, string> _irregulars = new(StringComparer.OrdinalIgnoreCase)
    {
        // Pronouns.
        ["I"] = "we",
        ["me"] = "us",
        ["he"] = "they",
        ["she"] = "they",
        ["them"] = "them",
        ["myself"] = "ourselves",
        ["yourself"] = "yourselves",
        ["itself"] = "themselves",
        ["herself"] = "themselves",
        ["himself"] = "themselves",
        ["themself"] = "themselves",
        ["is"] = "are",
        ["was"] = "were",
        ["has"] = "have",
        ["this"] = "these",
        ["that"] = "those",
        // Words ending in with a consonant and 'o'.
        ["echo"] = "echoes",
        ["dingo"] = "dingoes",
        ["volcano"] = "volcanoes",
        ["tornado"] = "tornadoes",
        ["torpedo"] = "torpedoes",
        // Ends with 'us'.
        ["genus"] = "genera",
        ["viscus"] = "viscera",
        // Ends with 'ma'.
        ["stigma"] = "stigmata",
        ["stoma"] = "stomata",
        ["dogma"] = "dogmata",
        ["lemma"] = "lemmata",
        ["schema"] = "schemata",
        ["anathema"] = "anathemata",
        // Other irregular rules.
        ["ox"] = "oxen",
        ["axe"] = "axes",
        ["die"] = "dice",
        ["yes"] = "yeses",
        ["foot"] = "feet",
        ["eave"] = "eaves",
        ["goose"] = "geese",
        ["tooth"] = "teeth",
        ["quiz"] = "quizzes",
        ["human"] = "humans",
        ["proof"] = "proofs",
        ["carve"] = "carves",
        ["valve"] = "valves",
        ["looey"] = "looies",
        ["thief"] = "thieves",
        ["groove"] = "grooves",
        ["pickaxe"] = "pickaxes",
        ["passerby"] = "passersby",
        ["cookie"] = "cookies"
    };

    #endregion

    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IDictionary<string, string> GetIrregularPlurals()
    {
        return _irregulars.GroupBy(keyValuePair => keyValuePair.Value, StringComparer.OrdinalIgnoreCase)
                          .ToDictionary(grouping => grouping.Key, grouping => grouping.First().Key, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static IDictionary<string, string> GetIrregularSingulars() => _irregulars;

    #endregion
}