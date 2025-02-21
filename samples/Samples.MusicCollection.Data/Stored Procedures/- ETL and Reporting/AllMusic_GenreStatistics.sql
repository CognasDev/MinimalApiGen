CREATE PROCEDURE [dbo].[AllMusic_GenreStatistics]

AS

SET NOCOUNT ON;

/* Provides totals of tracks and albums per genre, as well as sub and grand totals */
SELECT DISTINCT
	ISNULL ([dbo].[Genres].[Name],'Grand Total')    AS [GenreName],
	ISNULL ([dbo].[Albums].[Name],'(all albums)')   AS [AlbumName],
	COUNT  ([dbo].[Tracks].[TrackId])               AS [TrackCount]
FROM
	[dbo].[Genres]
LEFT OUTER JOIN [dbo].[Albums] ON
	[dbo].[Genres].[GenreId] = [dbo].[Albums].[GenreId]
LEFT OUTER JOIN [dbo].[Tracks] ON
	[dbo].[Albums].[AlbumId] = [dbo].[Tracks].[AlbumId]
GROUP BY ROLLUP
(
	[dbo].[Genres].[Name],
	[dbo].[Albums].[Name]
)
ORDER BY
	[GenreName],
	[TrackCount];