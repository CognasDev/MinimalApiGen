CREATE PROCEDURE [dbo].[Tracks_Delete]
(
	@TrackId INT
)
AS

SET NOCOUNT ON;

DELETE FROM
	[dbo].[Tracks]
WHERE
	[TrackId] = @TrackId;

SELECT @@ROWCOUNT;