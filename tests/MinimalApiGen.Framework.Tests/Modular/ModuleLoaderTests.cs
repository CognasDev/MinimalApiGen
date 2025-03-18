using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiGen.Framework.Modular;
using Moq;

namespace MinimalApiGen.Framework.Tests.Modular;

/// <summary>
/// 
/// </summary>
public sealed class ModuleLoaderTests
{
    #region Unit Test Declarations

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void RegisterDependencies_Called()
    {
        IServiceCollection serviceCollection = Mock.Of<IServiceCollection>();
        Action act = () => ModuleLoader.AddModules(serviceCollection, "MinimalApiGen.Framework.Tests");
        act.Should().Throw<NotImplementedException>();
    }

    #endregion
}