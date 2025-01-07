using QuickStartApi.Model;

namespace QuickStartApi.V3;

/// <summary>
/// 
/// </summary>
public sealed class BusinessLogicV3 : IBusinessLogicV3
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
        SampleModel sampleModel = new() { Id = id, Name = $"SampleModel {nameof(SampleModel.Id)}:{id}" };
        return await Task.FromResult(sampleModel).ConfigureAwait(false);
    }

    #endregion
}