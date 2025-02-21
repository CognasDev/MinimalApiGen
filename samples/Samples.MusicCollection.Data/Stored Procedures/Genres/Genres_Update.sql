CREATE PROCEDURE [dbo].[Genres_Update]
(
	@GenreId INT,
	@Name VARCHAR(250)
)
AS

SET NOCOUNT ON;

UPDATE [dbo].[Genres]
SET
	[Name] = @Name
WHERE
	[GenreId] = @GenreId;

EXEC [dbo].[Genres_SelectById] @GenreId;