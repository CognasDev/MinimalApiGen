using MinimalApiGen.Generators.Abstractions.Command.Put;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Command.Put;

/// <summary>
/// 
/// </summary>
public sealed class WithPutOperation : IWithPutOperation
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithPutOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression) => new WithPutOptionals();

    #endregion
}