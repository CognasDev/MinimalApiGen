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
    Task<IEnumerable<SampleModel>> GetModelsV2Async(SampleService1 sampleService1,
                                                    SampleKeyedService sampleKeyedService,
                                                    CancellationToken cancellationToken);

    #endregion
}