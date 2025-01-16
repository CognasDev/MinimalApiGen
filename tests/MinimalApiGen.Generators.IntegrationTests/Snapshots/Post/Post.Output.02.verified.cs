//HintName: SampleModel.SampleModelResponse.MappingSericeV1.g.cs
using MinimalApiGen.Framework.Mapping;
using SampleModel = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel;
using SampleModelResponse = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelResponse;

namespace TestNamespace;

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