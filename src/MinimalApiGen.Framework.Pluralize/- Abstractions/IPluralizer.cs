namespace MinimalApiGen.Framework.Pluralize;

/// <summary>
/// 
/// </summary>
internal interface IPluralizer
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