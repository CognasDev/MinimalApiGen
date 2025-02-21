using MinimalApiGen.Framework.Data;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
public interface IKeysQueryBusinessLogic
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Key>> SelectKeysAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Key?> SelectKeyAsync(int id);

    #endregion
}