CREATE PROCEDURE [dbo].[Albums_SelectByGenreIds]
(
	@Ids AS [dbo].[IdsParameterTable] READONLY
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
INNER JOIN
	@Ids ON [Id] = [GenreId];