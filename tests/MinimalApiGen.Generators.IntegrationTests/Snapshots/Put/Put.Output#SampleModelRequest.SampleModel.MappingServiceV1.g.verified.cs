//HintName: SampleModelRequest.SampleModel.MappingServiceV1.g.cs
using MinimalApiGen.Framework.Mapping;
using SampleModel = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel;
using SampleModelRequest = MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelRequest;

namespace TestNamespace;

/// <summary>
/// 
/// </summary>
public sealed class PutSampleModelRequestToSampleModelMappingServiceV1 : MappingServiceBase<SampleModelRequest, SampleModel>
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