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
    /// <exception cref="NotImplementedException"></exception>
    public IWithDeleteOperation WithDelete()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IWithPostOperation WithPost()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IWithPutOperation WithPut()
    {
        throw new NotImplementedException();
    }

    #endregion
}