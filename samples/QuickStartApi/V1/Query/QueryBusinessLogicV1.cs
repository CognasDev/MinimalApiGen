using QuickStartApi.V1.Model;

namespace QuickStartApi.V1.Query;

/// <summary>
/// 
/// </summary>
public sealed class QueryBusinessLogicV1 : IQueryBusinessLogicV1
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SampleModel>> GetModelsAsync(CancellationToken cancellationToken)
    {
        SampleModel sampleModel1 = new() { Id = 1, Name = $"{nameof(SampleModel)} 1" };
        SampleModel sampleModel2 = new() { Id = 2, Name = $"{nameof(SampleModel)} 2" };
        return await Task.FromResult<IEnumerable<SampleModel>>([sampleModel1, sampleModel2]).ConfigureAwait(false);
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