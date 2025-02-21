CREATE PROCEDURE [dbo].[Artists_Delete]
(
	@ArtistId INT
)
AS

SET NOCOUNT ON;

DELETE FROM
	[dbo].[Artists]
WHERE
	[ArtistId] = @ArtistId;

SELECT @@ROWCOUNT;