using MinimalApiGen.Framework.Mapping;
using Label = Samples.MusicCollection.Api.Labels.Label;
using LabelResponse = Samples.MusicCollection.Api.Labels.LabelResponse;

namespace Samples.MusicCollection.Api.Labels;

/// <summary>
/// 
/// </summary>
public sealed class PostLabelToLabelResponseMappingServiceV1 : MappingServiceBase<Label, LabelResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override LabelResponse Map(Label model)
    {
        LabelResponse response = new()
        {
			LabelId = model.LabelId,
			Name = model.Name
        };
        return response;
    }

    #endregion
}