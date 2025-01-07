using QuickStartApi.Model;
using QuickStartApi.Services;

namespace QuickStartApi.V2;

/// <summary>
/// 
/// </summary>
public sealed class BusinessLogicV2 : IBusinessLogicV2
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService1"></param>
    /// <param name="sampleKeyedService"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SampleModel>> GetModelsAsync(SampleService1 sampleService1,
                                                               SampleKeyedService sampleKeyedService,
                                                               CancellationToken cancellationToken)
    {
        SampleModel sampleModel1 = new() { Id = 1, Name = "SampleModel1" };
        SampleModel sampleModel2 = new() { Id = 2, Name = "SampleModel2" };
        List<SampleModel> sampleModels = [sampleModel1, sampleModel2];
        return await Task.FromResult<IEnumerable<SampleModel>>(sampleModels).ConfigureAwait(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sampleService1"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SampleModel> GetModelByIdAsync(int id,
                                                     SampleService1 sampleService1,
                                                     CancellationToken cancellationToken)
    {
        SampleModel sampleModel1 = new() { Id = id, Name = $"SampleModel {nameof(SampleModel.Id)}:{id}" };
        return await Task.FromResult(sampleModel1).ConfigureAwait(false);
    }

    #endregion
}