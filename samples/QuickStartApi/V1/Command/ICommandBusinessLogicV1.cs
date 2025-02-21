using QuickStartApi.V1.Model;

namespace QuickStartApi.V1.Command;

/// <summary>
/// 
/// </summary>
public interface ICommandBusinessLogicV1
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SampleModel?> PostModelAsync(SampleModel model, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SampleModel?> PutModelAsync(SampleModel model, CancellationToken cancellationToken);

    #endregion
}