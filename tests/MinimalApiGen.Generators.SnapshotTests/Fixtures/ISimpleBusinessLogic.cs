namespace MinimalApiGen.Generators.SnapshotTests.Fixtures;

/// <summary>
/// 
/// </summary>
public interface ISimpleBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SampleModel>> GetModelsAsync(CancellationToken cancellationToken);

    #endregion
}