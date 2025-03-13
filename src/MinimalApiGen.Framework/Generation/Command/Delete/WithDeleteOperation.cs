using MinimalApiGen.Generators.Abstractions.Command.Delete;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Command.Delete;

/// <summary>
/// 
/// </summary>
public sealed class WithDeleteOperation : IWithDeleteOperation
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithDeleteOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression) => new WithDeleteOptionals();

    #endregion
}