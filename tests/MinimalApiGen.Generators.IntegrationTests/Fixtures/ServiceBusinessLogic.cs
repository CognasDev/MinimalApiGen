﻿namespace MinimalApiGen.Generators.IntegrationTests.Fixtures;

/// <summary>
/// 
/// </summary>
public sealed class ServiceBusinessLogic : IServiceBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService1"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SampleModel>> GetModelsAsync(ISampleService1 sampleService1, CancellationToken cancellationToken)
    {
        return await Task.FromResult<IEnumerable<SampleModel>>([]).ConfigureAwait(false);
    }

    #endregion
}