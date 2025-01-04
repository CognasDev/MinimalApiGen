using System;
using System.Collections.Generic;

namespace MinimalApiGen.Generators.Pluralize.Rules;

/// <summary>
/// 
/// </summary>
internal static class NoPlurals
{
    #region Public Method Declarations 

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static ICollection<string> GetNoPlurals()
    {
        return new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "adulthood",
            "advice",
            "agenda",
            "aid",
            "aircraft",
            "alcohol",
            "ammo",
            "anime",
            "athletics",
            "audio",
            "bison",
            "blood",
            "bream",
            "buffalo",
            "butter",
            "carp",
            "cash",
            "chassis",
            "chess",
            "clothing",
            "cod",
            "commerce",
            "cooperation",
            "corps",
            "debris",
            "diabetes",
            "digestion",
            "elk",
            "energy",
            "equipment",
            "excretion",
            "expertise",
            "firmware",
            "flounder",
            "fun",
            "gallows",
            "garbage",
            "graffiti",
            "headquarters",
            "health",
            "herpes",
            "highjinks",
            "homework",
            "housework",
            "information",
            "jeans",
            "justice",
            "kudos",
            "labour",
            "literature",
            "machinery",
            "mackerel",
            "mail",
            "media",
            "mews",
            "moose",
            "music",
            "mud",
            "manga",
            "news",
            "only",
            "personnel",
            "pike",
            "plankton",
            "pliers",
            "police",
            "pollution",
            "premises",
            "rain",
            "research",
            "rice",
            "salmon",
            "scissors",
            "series",
            "sewage",
            "shambles",
            "shrimp",
            "software",
            "species",
            "staff",
            "swine",
            "tennis",
            "traffic",
            "transportation",
            "trout",
            "tuna",
            "wealth",
            "welfare",
            "whiting",
            "wildebeest",
            "wildlife",
            "you"
        };
    }

    #endregion
}