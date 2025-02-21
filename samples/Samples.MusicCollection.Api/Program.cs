using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Swagger;
using Samples.MusicCollection.Api.Albums;
using Samples.MusicCollection.Api.Artists;
using Samples.MusicCollection.Api.Genres;
using Samples.MusicCollection.Api.Keys;
using Samples.MusicCollection.Api.Labels;
using Samples.MusicCollection.Api.Tracks;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddMinimalApiFramework();
builder.AddMinimalApiFrameworkData();
builder.AddMinimalApiFramewokMappingServices();

builder.Services.AddSingleton<IArtistsQueryBusinessLogic, ArtistsQueryBusinessLogic>();
builder.Services.AddSingleton<IAlbumsQueryBusinessLogic, AlbumsQueryBusinessLogic>();
builder.Services.AddSingleton<IGenresQueryBusinessLogic, GenresQueryBusinessLogic>();
builder.Services.AddSingleton<IKeysQueryBusinessLogic, KeysQueryBusinessLogic>();
builder.Services.AddSingleton<ILabelsQueryBusinessLogic, LabelsQueryBusinessLogic>();
builder.Services.AddSingleton<ITracksQueryBusinessLogic, TracksQueryBusinessLogic>();

WebApplication webApplication = builder.Build();
webApplication.UseRouteMaps();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.AddSwagger();
}

webApplication.UseMinimalApiFramework();
webApplication.UseHttpsRedirection();
webApplication.Run();