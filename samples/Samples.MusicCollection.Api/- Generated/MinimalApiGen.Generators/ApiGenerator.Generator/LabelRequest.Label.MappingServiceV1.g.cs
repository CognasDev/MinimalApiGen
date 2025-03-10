using MinimalApiGen.Framework.Mapping;
using Label = Samples.MusicCollection.Api.Labels.Label;
using LabelRequest = Samples.MusicCollection.Api.Labels.LabelRequest;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
public sealed class PostLabelRequestToLabelMappingServiceV1 : MappingServiceBase<LabelRequest, Label>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public override Label Map(LabelRequest request)
    {
        Label model = new()
        {
			LabelId = request.LabelId,
			Name = request.Name,

        };
        return model;
    }

    #endregion
}