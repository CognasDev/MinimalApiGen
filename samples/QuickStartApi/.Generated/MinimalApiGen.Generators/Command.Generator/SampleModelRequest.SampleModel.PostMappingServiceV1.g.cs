using MinimalApiGen.Framework.Mapping;
using SampleModel = QuickStartApi.V1.Model.SampleModel;
using SampleModelRequest = QuickStartApi.V1.Model.SampleModelRequest;

namespace QuickStartApi.V1.Command;

/// <summary>
/// 
/// </summary>
public sealed class PostSampleModelRequestToSampleModelMappingServiceV1 : MappingServiceBase<SampleModelRequest, SampleModel>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public override SampleModel Map(SampleModelRequest request)
    {
        SampleModel model = new()
        {
			Id = request.Id,
			Name = request.Name,

        };
        return model;
    }

    #endregion
}