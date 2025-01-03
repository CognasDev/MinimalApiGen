using MinimalApiGen.Generators.Abstractions.Query;

namespace MinimalApiGen.Generators.Abstractions.Common;

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
    IQueryWithResponse WithResponse<TResponse>();

    #endregion
}