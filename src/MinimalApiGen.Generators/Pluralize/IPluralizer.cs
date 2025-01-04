namespace MinimalApiGen.Generators.Pluralize;

/// <summary>
/// 
/// </summary>
public interface IPluralizer
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    string Pluralize(string word);

    #endregion
}