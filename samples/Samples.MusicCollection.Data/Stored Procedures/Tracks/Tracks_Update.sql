CREATE PROCEDURE [dbo].[Tracks_Update]
(
	@TrackId INT,
	@AlbumId INT,
	@GenreId INT,
	@KeyId INT,
	@TrackNumber INT,
	@Name VARCHAR(250),
	@Bpm FLOAT
)
AS

SET NOCOUNT ON;

UPDATE [dbo].[Tracks]
SET
	[AlbumId] = @AlbumId,
	[GenreId] = @GenreId,
	[KeyId] = @KeyId,
	[TrackNumber] = @TrackNumber,
	[Name] = @Name,
	[Bpm] = @Bpm
WHERE
	[TrackId] = @TrackId;

EXEC [dbo].[Tracks_SelectById] @TrackId;