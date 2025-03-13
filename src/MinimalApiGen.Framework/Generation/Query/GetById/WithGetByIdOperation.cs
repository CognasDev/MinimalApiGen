using MinimalApiGen.Generators.Abstractions.Query.GetById;
using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Query.GetById;

/// <summary>
/// 
/// </summary>
public sealed class WithGetByIdOperation : IWithGetByIdOperation
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithGetByIdOptionals WithHandler<THandler>(Expression<Func<THandler, Delegate>> expression) => new WithGetByIdOptionals();

    #endregion
}