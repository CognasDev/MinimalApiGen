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
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IWithDeleteOptionals WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression) => new WithDeleteOptionals();

    #endregion
}