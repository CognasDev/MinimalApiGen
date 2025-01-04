namespace MinimalApiGen.Generators.SnapshotTests.Fixtures;

/// <summary>
/// 
/// </summary>
public sealed class SimpleBusinessLogic : ISimpleBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SampleModel>> GetModelsAsync(CancellationToken cancellationToken)
    {
        return await Task.FromResult<IEnumerable<SampleModel>>([]).ConfigureAwait(false);
    }

    #endregion
}