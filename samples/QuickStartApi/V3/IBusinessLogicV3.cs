using QuickStartApi.Model;

namespace QuickStartApi.V3;

/// <summary>
/// 
/// </summary>
public interface IBusinessLogicV3
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SampleModel>> GetModelsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SampleModel> GetModelByIdAsync(int id, CancellationToken cancellationToken);

    #endregion
}