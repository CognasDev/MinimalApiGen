namespace MinimalApiGen.Framework.Data;

/// <summary>
/// 
/// </summary>
public sealed record Parameter : IParameter
{
    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 
    /// </summary>
    public object? Value { get; }

    #endregion

    #region Constructor / Finaliser Declarations

    /// <summary>
    /// Default constructor for <see cref="Parameter"/>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Parameter(string name, object? value)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        Name = name;
        Value = value;
    }

    #endregion
}