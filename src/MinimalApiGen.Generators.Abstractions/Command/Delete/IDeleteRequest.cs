namespace MinimalApiGen.Generators.Abstractions.Command.Delete;

/// <summary>
/// 
/// </summary>
public interface IDeleteRequest
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <returns></returns>
    IWithDeleteWithRequest WithRequest<TRequest>();

    #endregion
}