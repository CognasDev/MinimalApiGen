CREATE PROCEDURE [dbo].[Albums_Update]
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

UPDATE [dbo].[Albums]
SET
	[ArtistId] = @ArtistId,
	[GenreId] = @GenreId,
	[LabelId] = @LabelId,
	[Name] = @Name,
	[ReleaseDate] = @ReleaseDate
WHERE
	[AlbumId] = @AlbumId;

EXEC [dbo].[Albums_SelectById] @AlbumId;