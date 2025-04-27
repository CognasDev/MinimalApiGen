using Microsoft.AspNetCore.Http;

namespace MinimalApiGen.Generators.IntegrationTests.Fixtures;

/// <summary>
/// 
/// </summary>
public sealed class SampleEndpointFilter : IEndpointFilter
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        throw new NotImplementedException();
    }

    #endregion
}