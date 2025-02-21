using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Swagger;
using Samples.MusicCollection.Api.Albums;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddMinimalApiFramework();
builder.AddMinimalApiFrameworkData();
builder.AddMappingServices();

builder.Services.AddSingleton<IAlbumQueryBusinessLogic, AlbumQueryBusinessLogic>();

WebApplication webApplication = builder.Build();
webApplication.UseRouteMaps();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.AddSwagger();
}

webApplication.UseMinimalApiFramework();
webApplication.UseHttpsRedirection();
webApplication.Run();