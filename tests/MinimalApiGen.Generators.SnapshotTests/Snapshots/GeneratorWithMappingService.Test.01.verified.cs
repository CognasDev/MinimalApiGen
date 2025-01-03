//HintName: SampleModelSampleModelResponse.MappingSericeV1.g.cs
using MinimalApiGen.Framework.Mapping;
using SampleModel = MinimalApiGen.Generators.SnapshotTests.Fixtures.SampleModel;
using SampleModelResponse = MinimalApiGen.Generators.SnapshotTests.Fixtures.SampleModelResponse;

namespace MinimalApiGen.Generators.SnapshotTests.Fixtures;

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