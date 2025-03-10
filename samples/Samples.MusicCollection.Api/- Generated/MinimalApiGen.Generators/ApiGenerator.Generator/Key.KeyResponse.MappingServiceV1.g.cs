using MinimalApiGen.Framework.Mapping;
using Key = Samples.MusicCollection.Api.Keys.Key;
using KeyResponse = Samples.MusicCollection.Api.Keys.KeyResponse;

namespace Samples.MusicCollection.Api.Keys;

/// <summary>
/// 
/// </summary>
public sealed class GetKeyToKeyResponseMappingServiceV1 : MappingServiceBase<Key, KeyResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override KeyResponse Map(Key model)
    {
        KeyResponse response = new()
        {
			KeyId = model.KeyId,
			CamelotCode = model.CamelotCode,
			Name = model.Name,

        };
        return response;
    }

    #endregion
}