using QuickStartApi.Model;
using QuickStartApi.Services;

namespace QuickStartApi.V1;

/// <summary>
/// 
/// </summary>
public sealed class BusinessLogicV1 : IBusinessLogicV1
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService1"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SampleModel>> GetModelsV1Async(SampleService1 sampleService1, CancellationToken cancellationToken)
    {
        SampleModel sampleModel1 = new() { Id = 1, Name = "SampleModel1 - BusinessLogicV1" };
        List<SampleModel> sampleModels = [sampleModel1];
        return await Task.FromResult<IEnumerable<SampleModel>>(sampleModels).ConfigureAwait(false);
    }

    #endregion
}