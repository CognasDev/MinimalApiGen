using System.Linq.Expressions;

namespace MinimalApiGen.Framework.Generation.Get;

/// <summary>
/// 
/// </summary>
public sealed class WithGetWithBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBusinessLogic"></typeparam>
    /// <param name="expression"></param>
    /// <returns></returns>
    public WithGetOptionals WithBusinessLogic<TBusinessLogic>(Expression<Func<TBusinessLogic, Delegate>> expression) => new();

    #endregion
}