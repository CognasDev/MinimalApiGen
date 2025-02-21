CREATE PROCEDURE [dbo].[Artists_SelectById]
(
	@ArtistId INT
)
AS

SET NOCOUNT ON;

SELECT
	[ArtistId],
	[Name]
FROM
	[dbo].[Artists]
WHERE
	[ArtistId] = @ArtistId;