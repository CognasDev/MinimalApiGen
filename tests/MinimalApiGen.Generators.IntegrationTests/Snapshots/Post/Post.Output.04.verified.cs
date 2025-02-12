//HintName: MappingRegistrations.Command.g.cs
using MinimalApiGen.Framework.Mapping;

namespace MinimalApiGen.Framework.Generation;

/// <summary>
/// 
/// </summary>
public static class CommandMappingRegistrations
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    public static void UseCommandMappingServices(this WebApplicationBuilder builder)
    {
		builder.Services.AddSingleton<IMappingService<MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelRequest, MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel>, TestNamespace.PostSampleModelRequestToSampleModelMappingServiceV1>();
		builder.Services.AddSingleton<IMappingService<MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModel, MinimalApiGen.Generators.IntegrationTests.Fixtures.SampleModelResponse>, TestNamespace.PostSampleModelToSampleModelResponseMappingServiceV1>();

    }
}