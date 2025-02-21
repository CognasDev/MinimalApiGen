CREATE PROCEDURE [dbo].[Artists_Insert]
(
	@ArtistId INT,
	@Name VARCHAR(250)
)
AS

SET NOCOUNT ON;

INSERT INTO [dbo].[Artists]
(
	[Name]
)
VALUES
(
	@Name
);

DECLARE @newArtistId INT;
SELECT @newArtistId = CAST(SCOPE_IDENTITY() AS INT);

EXEC [dbo].[Artists_SelectById] @newArtistId;