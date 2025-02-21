CREATE PROCEDURE [dbo].[Genres_Delete]
(
	@GenreId INT
)
AS

SET NOCOUNT ON;

DELETE FROM
	[dbo].[Genres]
WHERE
	[GenreId] = @GenreId;

SELECT @@ROWCOUNT;