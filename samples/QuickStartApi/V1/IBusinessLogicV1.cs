using QuickStartApi.Model;
using QuickStartApi.Services;

namespace QuickStartApi.V1;

/// <summary>
/// 
/// </summary>
public interface IBusinessLogicV1
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService1"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SampleModel>> GetModelsV1Async(SampleService1 sampleService1, CancellationToken cancellationToken);

    #endregion
}