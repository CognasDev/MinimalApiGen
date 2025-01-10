using QuickStartApi.V1.Model;

namespace QuickStartApi.V1.Query;

/// <summary>
/// 
/// </summary>
public interface IQueryBusinessLogicV1
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