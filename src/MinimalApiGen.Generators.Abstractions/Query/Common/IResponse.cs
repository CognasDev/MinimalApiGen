using MinimalApiGen.Generators.Abstractions.Query.Get;

namespace MinimalApiGen.Generators.Abstractions.Query.Common;

/// <summary>
/// 
/// </summary>
public interface IResponse
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    IWithGetWithResponse WithResponse<TResponse>();

    #endregion
}