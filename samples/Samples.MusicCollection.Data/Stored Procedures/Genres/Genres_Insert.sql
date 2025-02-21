CREATE PROCEDURE [dbo].[Genres_Insert]
(
	@GenreId INT,
	@Name VARCHAR(250)
)
AS

SET NOCOUNT ON;

INSERT INTO [dbo].[Genres]
(
	[Name]
)
VALUES
(
	@Name
);

DECLARE @newGenreId INT;
SELECT @newGenreId = CAST(SCOPE_IDENTITY() AS INT);

EXEC [dbo].[Genres_SelectById] @newGenreId;