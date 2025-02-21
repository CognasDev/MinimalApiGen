CREATE PROCEDURE [dbo].[Albums_Insert]
(
	@AlbumId INT,
	@ArtistId INT,
	@GenreId INT,
	@LabelId INT,
	@Name VARCHAR(250),
	@ReleaseDate SMALLDATETIME
)
AS

SET NOCOUNT ON;

INSERT INTO [dbo].[Albums]
(
	[ArtistId],
	[GenreId],
	[LabelId],
	[Name],
	[ReleaseDate]
)
VALUES
(
	@ArtistId,
	@GenreId,
	@LabelId,
	@Name,
	@ReleaseDate
);

DECLARE @newAlbumId INT;
SELECT @newAlbumId = CAST(SCOPE_IDENTITY() AS INT);

EXEC [dbo].[Albums_SelectById] @newAlbumId;