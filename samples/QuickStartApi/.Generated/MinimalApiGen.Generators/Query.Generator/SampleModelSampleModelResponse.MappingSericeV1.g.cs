using MinimalApiGen.Framework.Mapping;
using SampleModel = QuickStartApi.Model.SampleModel;
using SampleModelResponse = QuickStartApi.Model.SampleModelResponse;

namespace QuickStartApi.V1;

/// <summary>
/// 
/// </summary>
public sealed class SampleModelToSampleModelResponseMappingService : MappingServiceBase<SampleModel, SampleModelResponse>
{
    #region Public Method Declarations

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public override SampleModelResponse Map(SampleModel model)
    {
        SampleModelResponse response = new()
        {
			Id = model.Id,
			Name = model.Name,

        };
        return response;
    }

    #endregion
}