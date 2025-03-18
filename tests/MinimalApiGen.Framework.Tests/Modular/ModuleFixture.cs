using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.Modular;

namespace MinimalApiGen.Framework.Tests.Modular;

/// <summary>
/// 
/// </summary>
public sealed class ModuleFixture : ModuleBase
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <exception cref="NotImplementedException"></exception>
    public override void RegisterDependencies(IServiceCollection serviceCollection)
    {
        throw new NotImplementedException();
    }

    #endregion
}