using MinimalApiGen.Framework.Generation.Command.Delete;
using MinimalApiGen.Framework.Generation.Command.Post;
using MinimalApiGen.Framework.Generation.Command.Put;
using MinimalApiGen.Generators.Abstractions.Command;
using MinimalApiGen.Generators.Abstractions.Command.Delete;
using MinimalApiGen.Generators.Abstractions.Command.Post;
using MinimalApiGen.Generators.Abstractions.Command.Put;

namespace MinimalApiGen.Framework.Generation.Command;

/// <summary>
/// 
/// </summary>
public sealed class CommandOperations : ICommandOperations
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithPostOperation WithPost() => new WithPostOperation();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithPutOperation WithPut() => new WithPutOperation();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IWithDeleteOperation WithDelete() => new WithDeleteOperation();

    #endregion
}