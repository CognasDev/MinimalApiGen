//HintName: MappingRegistrations.g.cs
using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class MappingRegistrations
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void AddMappingServices(this WebApplicationBuilder builder)
    {
		builder.Services.AddSingleton<IMappingService<MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel, MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelResponse>, TestNamespace.PutSampleModelToSampleModelResponseMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelRequest, MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel>, TestNamespace.PutSampleModelRequestToSampleModelMappingServiceV1>();

    }
}