namespace MinimalApiGen.Generators.IntegrationTests.Fixtures;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SampleModel> GetModelByIdAsync(int id, CancellationToken cancellationToken)
    {
        SampleModel sampleModel = new() { Id = 5, Name = "SampleModel" };
        return await Task.FromResult(sampleModel).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SampleModel?> PostModelAsync(SampleModel model, CancellationToken cancellationToken)
    {
        SampleModel postedModel = model with { Name = $"{model.Name} - Posted" };
        return await Task.FromResult<SampleModel?>(postedModel).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SampleModel?> PutModelAsync(SampleModel model, CancellationToken cancellationToken)
    {
        SampleModel postedModel = model with { Name = $"{model.Name} - Put" };
        return await Task.FromResult<SampleModel?>(postedModel).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task DeleteModelAsync(SampleModel model, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
    }

    #endregion
}