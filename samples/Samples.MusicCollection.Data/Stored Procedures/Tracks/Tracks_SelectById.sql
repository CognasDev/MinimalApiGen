CREATE PROCEDURE [dbo].[Tracks_SelectById]
(
	@TrackId INT
)
AS

SET NOCOUNT ON;

SELECT
	[TrackId],
	[AlbumId],
	[GenreId],
	[KeyId],
	[TrackNumber],
	[Name],
	[Bpm]
FROM
	[dbo].[Tracks]
WHERE
	[TrackId] = @TrackId;