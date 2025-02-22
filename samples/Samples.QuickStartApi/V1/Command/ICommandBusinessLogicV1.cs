using Samples.QuickStartApi.V1.Model;

namespace Samples.QuickStartApi.V1.Command;

/// <summary>
/// 
/// </summary>
public interface ICommandBusinessLogicV1
{
    #region Method Declarations

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteModelAsync(int id, CancellationToken cancellationToken);

    #endregion
}