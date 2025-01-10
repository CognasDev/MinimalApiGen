using QuickStartApi.V1.Model;

namespace QuickStartApi.V1.Command;

/// <summary>
/// 
/// </summary>
public sealed class CommandBusinessLogicV1 : ICommandBusinessLogicV1
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SampleModel?> PostModelAsync(SampleModel model, CancellationToken cancellationToken)
    {
        SampleModel postedModel = model with { Name = $"{model.Name} - Posted" };
        return await Task.FromResult<SampleModel?>(postedModel).ConfigureAwait(false);
    }

    #endregion
}