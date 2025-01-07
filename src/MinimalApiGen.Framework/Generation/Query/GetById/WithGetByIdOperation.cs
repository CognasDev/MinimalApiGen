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
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithGetByIdOptionals WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression) => new WithGetByIdOptionals();

    #endregion
}