using System.Text.RegularExpressions;

namespace MinimalApiGen.Framework.Pluralize.Rules;

/// <summary>
/// 
/// </summary>
public sealed record ReplaceRule
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required Regex Condition { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string ReplaceWith { get; init; }

    #endregion
}