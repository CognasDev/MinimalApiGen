using MinimalApiGen.Generators.Abstractions.Command.Post;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Command.Post;

/// <summary>
/// 
/// </summary>
public sealed class WithPostOperation : IWithPostOperation
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithPostOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression) => new WithPostOptionals();

    #endregion
}