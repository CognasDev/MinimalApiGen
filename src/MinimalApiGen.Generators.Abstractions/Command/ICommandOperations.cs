using MinimalApiGen.Generators.Abstractions.Command.Delete;
using MinimalApiGen.Generators.Abstractions.Command.Post;
using MinimalApiGen.Generators.Abstractions.Command.Put;

namespace MinimalApiGen.Generators.Abstractions.Command;

/// <summary>
/// 
/// </summary>
public interface ICommandOperations
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithPostOperation WithPost();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithPutOperation WithPut();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IWithDeleteOperation WithDelete();

    #endregion
}