using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Tests.Mapping;

/// <summary>
/// 
/// </summary>
internal sealed class MappingServiceFixture : MappingServiceBase<int, string>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public override string Map(int source) => source.ToString();

    #endregion
}