namespace MinimalApiGen.Generators.Abstractions.Command.Put;

/// <summary>
/// 
/// </summary>
public interface IPutResponse
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    IWithPutWithResponse WithResponse<TResponse>();

    #endregion
}