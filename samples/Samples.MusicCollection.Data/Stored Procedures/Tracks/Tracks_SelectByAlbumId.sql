CREATE PROCEDURE [dbo].[Tracks_SelectByAlbumId]
(
	@AlbumId INT
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
	[AlbumId] = @AlbumId;