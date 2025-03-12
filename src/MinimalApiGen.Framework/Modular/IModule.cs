using Microsoft.Extensions.DependencyInjection;

namespace MinimalApiGen.Framework.Modular;

/// <summary>
/// 
/// </summary>
public interface IModule
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    void RegisterDependencies(IServiceCollection serviceCollection);

    #endregion
}