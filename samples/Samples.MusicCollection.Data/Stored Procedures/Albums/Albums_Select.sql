CREATE PROCEDURE [dbo].[Albums_Select]

AS

SET NOCOUNT ON;

SELECT
	[AlbumId],
	[ArtistId],
	[GenreId],
	[LabelId],
	[Name],
	[ReleaseDate]
FROM
	[dbo].[Albums];