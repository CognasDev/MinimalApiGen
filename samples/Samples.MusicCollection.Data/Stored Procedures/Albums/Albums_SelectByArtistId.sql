CREATE PROCEDURE [dbo].[Albums_SelectByArtistId]
(
	@artistId INT
)
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
	[dbo].[Albums]
WHERE
	[ArtistId] = @artistId;