using MinimalApiGen.Generators.Abstractions.Command.Post;

namespace MinimalApiGen.Framework.Generation.Command.Post;

/// <summary>
/// 
/// </summary>
public sealed class WithPostWithKeyedServices : IWithPostWithKeyedServices
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public IWithPostWithResponse WithResponse<TResponse>() => new WithPostWithResponse();

    #endregion

    #region Public Method Declarations - Services

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    public IWithPostWithServices WithServices<TService1>() => new WithPostWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    public IWithPostWithServices WithServices<TService1, TService2>() => new WithPostWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    public IWithPostWithServices WithServices<TService1, TService2, TService3>() => new WithPostWithServices();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TService1"></typeparam>
    /// <typeparam name="TService2"></typeparam>
    /// <typeparam name="TService3"></typeparam>
    /// <typeparam name="TService4"></typeparam>
    public IWithPostWithServices WithServices<TService1, TService2, TService3, TService4>() => new WithPostWithServices();

    #endregion
}