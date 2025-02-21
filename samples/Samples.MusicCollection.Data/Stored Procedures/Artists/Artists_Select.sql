CREATE PROCEDURE [dbo].[Artists_Select]

AS

SET NOCOUNT ON;

SELECT
	[ArtistId],
	[Name]
FROM
	[dbo].[Artists];