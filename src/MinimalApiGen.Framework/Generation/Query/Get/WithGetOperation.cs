using MinimalApiGen.Generators.Abstractions.Query.Get;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Query.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetOperation : IWithGetOperation
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithGetOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression) => new WithGetOptionals();

    #endregion
}