namespace MinimalApiGen.Framework.Pluralize;

/// <summary>
/// 
/// </summary>
public interface IPluralizer
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    string Pluralize<T>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    string Pluralize(string word);

    #endregion
}