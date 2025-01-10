namespace MinimalApiGen.Generators.Generation.Command.Results;

/// <summary>
/// 
/// </summary>
internal sealed record ModelIdPropertyResult()
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public required string PropertyName { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required string PropertyType { get; init; }

    /// <summary>
    /// 
    /// </summary>
    public required bool IsNullable { get; init; }

    #endregion
}