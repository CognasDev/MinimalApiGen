CREATE PROCEDURE [dbo].[Albums_SelectById]
(
	@AlbumId INT
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
	[AlbumId] = @AlbumId;