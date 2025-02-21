CREATE PROCEDURE [dbo].[Tracks_Select]

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
	[dbo].[Tracks];