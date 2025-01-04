namespace MinimalApiGen.Generators.SnapshotTests.Fixtures;

/// <summary>
/// 
/// </summary>
public sealed class ServiceBusinessLogic : IServiceBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SampleModel>> GetModelsAsync(ISampleService sampleService, CancellationToken cancellationToken)
    {
        return await Task.FromResult<IEnumerable<SampleModel>>([]).ConfigureAwait(false);
    }

    #endregion
}