using MinimalApiGen.Framework.Mapping;
using SampleModel = Samples.QuickStartApi.V1.Model.SampleModel;
using SampleModelRequest = Samples.QuickStartApi.V1.Model.SampleModelRequest;

namespace Samples.QuickStartApi.V1.Command;

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