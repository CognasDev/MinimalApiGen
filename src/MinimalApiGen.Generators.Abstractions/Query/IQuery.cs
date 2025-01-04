using MinimalApiGen.Generators.Abstractions.Common;
using MinimalApiGen.Generators.Abstractions.Get;
using MinimalApiGen.Generators.Abstractions.GetById;

namespace MinimalApiGen.Generators.Abstractions.Query;

/// <summary>
/// 
/// </summary>
public interface IQuery : INamespace, INamespaceOf
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithGet WithGet();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithGetById WithGetById();

    #endregion
}