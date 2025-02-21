CREATE PROCEDURE [dbo].[Artists_Update]
(
	@ArtistId INT,
	@Name VARCHAR(250)
)
AS

SET NOCOUNT ON;

UPDATE [dbo].[Artists]
SET
	[Name] = @Name
WHERE
	[ArtistId] = @ArtistId;

EXEC [dbo].[Artists_SelectById] @ArtistId;