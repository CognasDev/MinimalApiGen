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
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithGetOptionals WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression) => new WithGetOptionals();

    #endregion
}