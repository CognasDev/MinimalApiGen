CREATE PROCEDURE [dbo].[Albums_Delete]
(
	@AlbumId INT
)
AS

SET NOCOUNT ON;

DELETE FROM
	[dbo].[Albums]
WHERE
	[AlbumId] = @AlbumId;

SELECT @@ROWCOUNT;