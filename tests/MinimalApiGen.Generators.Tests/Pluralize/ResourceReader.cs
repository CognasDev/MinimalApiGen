using System.Reflection;
using System.Text;

namespace MinimalApiGen.Generators.Tests.Pluralize;

/// <summary>
/// 
/// </summary>
internal static class ResourceReader
{
    #region Field Declarations

    private const string _resourcesPath = "MinimalApiGen.Generators.Tests.Pluralize.Resources";
    private static readonly Lazy<string> _inputData;
    private static readonly Lazy<string> _pluralToSingularExceptions;
    private static readonly Lazy<string> _singularToPluralExceptions;

    #endregion

    #region Property Declarations

    /// <summary>
    /// 
    /// </summary>
    public static string InputData => _inputData.Value;

    /// <summary>
    /// 
    /// </summary>
    public static string PluralToSingularExceptions => _pluralToSingularExceptions.Value;

    /// <summary>
    /// 
    /// </summary>
    public static string SingularToPluralExceptions => _singularToPluralExceptions.Value;

    #endregion

    #region Constructor Declarations

    /// <summary>
    /// 
    /// </summary>
    static ResourceReader()
    {
        _inputData = new Lazy<string>(() => GetFileContents($"{_resourcesPath}.InputData.csv"));
        _pluralToSingularExceptions = new Lazy<string>(() => GetFileContents($"{_resourcesPath}.PluralToSingularExceptions.csv"));
        _singularToPluralExceptions = new Lazy<string>(() => GetFileContents($"{_resourcesPath}.SingularToPluralExceptions.csv"));
    }

    #endregion

    #region Private Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="namespaceAndFileName"></param>
    /// <returns></returns>
    private static string GetFileContents(string namespaceAndFileName)
    {
        using Stream stream = typeof(ResourceReader).GetTypeInfo().Assembly.GetManifestResourceStream(namespaceAndFileName)!;
        using StreamReader reader = new(stream, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    #endregion
}