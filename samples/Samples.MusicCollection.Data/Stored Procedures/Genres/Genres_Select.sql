CREATE PROCEDURE [dbo].[Genres_Select]

AS

SET NOCOUNT ON;

SELECT
	[GenreId],
	[Name]
FROM
	[dbo].[Genres];