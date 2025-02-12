using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Swagger;
using QuickStartApi.V1.Command;
using QuickStartApi.V1.Query;
using QuickStartApi.V1.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddMinimalApiGenFramework();
builder.AddCommandMappingServices();
builder.AddQueryMappingServices();

builder.Services.AddScoped<ICommandBusinessLogicV1, CommandBusinessLogicV1>();
builder.Services.AddScoped<IQueryBusinessLogicV1, QueryBusinessLogicV1>();
builder.Services.AddScoped<SampleService1>();
builder.Services.AddScoped<SampleService2>();

WebApplication webApplication = builder.Build();
webApplication.UseCommandRouteMaps();
webApplication.UseQueryRouteMaps();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.AddSwagger();
}

webApplication.UseMinimalApiGenFramework();
webApplication.UseHttpsRedirection();
webApplication.Run();