CREATE PROCEDURE [dbo].[Genres_SelectById]
(
	@GenreId INT
)
AS

SET NOCOUNT ON;

SELECT
	[GenreId],
	[Name]
FROM
	[dbo].[Genres]
WHERE
	[GenreId] = @GenreId;