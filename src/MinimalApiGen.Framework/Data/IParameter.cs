namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public interface IParameter
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    string Name { get; }

    /// <summary>
    /// 
    /// </summary>
    object? Value { get; }

    #endregion
}