using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Swagger;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddMinimalApiGenFramework();


WebApplication webApplication = builder.Build();
webApplication.UseRouteMaps();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.AddSwagger();
}

webApplication.UseMinimalApiGenFramework();
webApplication.UseHttpsRedirection();
webApplication.Run();