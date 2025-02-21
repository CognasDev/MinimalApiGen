CREATE PROCEDURE [dbo].[Tracks_Insert]
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

INSERT INTO [dbo].[Tracks]
(
	[AlbumId],
	[GenreId],
	[KeyId],
	[TrackNumber],
	[Name],
	[Bpm]
)
VALUES
(
	@AlbumId,
	@GenreId,
	@KeyId,
	@TrackNumber,
	@Name,
	@Bpm
);

DECLARE @newTrackId INT;
SELECT @newTrackId = CAST(SCOPE_IDENTITY() AS INT);

EXEC [dbo].[Tracks_SelectById] @newTrackId;