namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
public interface ILabelsQueryHandler
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Label>> SelectLabelsAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Label?> SelectLabelAsync(int id);

    #endregion
}