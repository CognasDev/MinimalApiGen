using FluentValidation;
using MinimalApiGen.Framework.Data;
using MinimalApiGen.Framework.Extensions;
using MinimalApiGen.Framework.Generation;
using MinimalApiGen.Framework.Logging;
using MinimalApiGen.Framework.Swagger;
using Samples.MusicCollection.Api.Albums;
using Samples.MusicCollection.Api.Artists;
using Samples.MusicCollection.Api.Genres;
using Samples.MusicCollection.Api.Keys;
using Samples.MusicCollection.Api.Labels;
using Samples.MusicCollection.Api.Tracks;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.ConfigureLogging(LoggingType.File);

builder.AddMinimalApiFramework();
builder.AddMinimalApiFrameworkData();
builder.AddMinimalApiFramewokMappingServices();

builder.Services.AddValidatorsFromAssemblyContaining<ArtistRequestValidator>(ServiceLifetime.Singleton);

builder.Services.AddSingleton<IArtistsCommandHandler, ArtistsCommandHandler>();
builder.Services.AddSingleton<IAlbumsCommandHandler, AlbumsCommandHandler>();
builder.Services.AddSingleton<IGenresCommandHandler, GenresCommandHandler>();
builder.Services.AddSingleton<ILabelsCommandHandler, LabelsCommandHandler>();
builder.Services.AddSingleton<ITracksCommandHandler, TracksCommandHandler>();

builder.Services.AddSingleton<IArtistsQueryHandler, ArtistsQueryHandler>();
builder.Services.AddSingleton<IAlbumsQueryHandler, AlbumsQueryHandler>();
builder.Services.AddSingleton<IGenresQueryHandler, GenresQueryHandler>();
builder.Services.AddSingleton<IKeysQueryHandler, KeysQueryHandler>();
builder.Services.AddSingleton<ILabelsQueryHandler, LabelsQueryHandler>();
builder.Services.AddSingleton<ITracksQueryHandler, TracksQueryHandler>();

WebApplication webApplication = builder.Build();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.AddSwagger();
}

webApplication.UseMinimalApiFramework();
webApplication.Run();