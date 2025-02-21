using MinimalApiGen.Framework.Generation;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
[ApiGenerator]
public sealed class KeysQueryGenerator
{
    #region Constructor Declarations

    /// <summary>
    ///
    /// </summary>
    public KeysQueryGenerator()
    {
        ApiGeneration.Query<Key>().WithNamespaceOf<IKeysQueryBusinessLogic>()
                                     .WithModelId(model => model.KeyId)
                                     .WithGet()
                                         .WithBusinessLogic<IKeysQueryBusinessLogic>(query => query.SelectKeysAsync)
                                         .WithResponse<KeyResponse>()
                                         .WithMappingService()
                                         .CachedFor(TimeSpan.FromHours(1))
                                         .WithVersion(1)
                                     .WithGetById()
                                         .WithBusinessLogic<IKeysQueryBusinessLogic>(query => query.SelectKeyAsync)
                                         .WithResponse<KeyResponse>()
                                         .WithMappingService()
                                         .CachedFor(TimeSpan.FromHours(1))
                                         .WithVersion(1);

    }

    #endregion
}