namespace MinimalApiGen.Generators.Abstractions.Command.Put;

/// <summary>
/// 
/// </summary>
public interface IPutRequest
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns></returns>
    IWithPutWithRequest WithRequest<TRequest>();

    #endregion
}