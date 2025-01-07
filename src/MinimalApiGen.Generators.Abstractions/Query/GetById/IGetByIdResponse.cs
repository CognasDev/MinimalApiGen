namespace MinimalApiGen.Generators.Abstractions.Query.GetById;

/// <summary>
/// 
/// </summary>
public interface IGetByIdResponse
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    IWithGetByIdWithResponse WithResponse<TResponse>();

    #endregion
}