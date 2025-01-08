using QuickStartApi.Model;
using QuickStartApi.Services;

namespace QuickStartApi.V2;

/// <summary>
/// 
/// </summary>
public interface IBusinessLogicV2
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService1"></param>
    /// <param name="sampleKeyedService"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SampleModel>> GetModelsAsync(SampleService1 sampleService1,
                                                  SampleKeyedService sampleKeyedService,
                                                  CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="sampleService1"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SampleModel> GetModelByIdAsync(int id,
                                        SampleService1 sampleService1,
                                        CancellationToken cancellationToken);
    #endregion
}