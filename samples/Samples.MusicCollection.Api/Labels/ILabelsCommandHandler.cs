namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
public interface ILabelsCommandHandler
{
    #region Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Label> InsertLabelAsync(Label album);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<Label> UpdateLabelAsync(Label album);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteLabelAsync(int id);

    #endregion
}