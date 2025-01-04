namespace MinimalApiGen.Generators.SnapshotTests.Fixtures;

/// <summary>
/// 
/// </summary>
public interface IServiceBusinessLogic
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sampleService"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<SampleModel>> GetModelsAsync(ISampleService sampleService, CancellationToken cancellationToken);

    #endregion
}