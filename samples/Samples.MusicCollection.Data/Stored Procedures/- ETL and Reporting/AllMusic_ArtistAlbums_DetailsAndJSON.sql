CREATE PROCEDURE [dbo].[AllMusic_ArtistAlbums_DetailsAndJSON]

AS

SET NOCOUNT ON;

WITH
[CTE_AlbumTracksCount] AS
(
	--Common table expression to get track count per album.
	SELECT
		[Albums].[AlbumId]	AS [AlbumId],
		COUNT(*)			AS [TrackCount]
	FROM
		[Albums]
	INNER JOIN
		[Tracks] ON [Tracks].[AlbumId] = [Albums].[AlbumId]
	GROUP BY
		[Albums].[AlbumId]
),
[CTE_BpmAverage] AS
(
	--Common table expression to calculate average bpm of tracks on an album (where provided).
	SELECT
		[AlbumId]							AS [AlbumId],
		CAST(AVG([Bpm]) AS DECIMAL(5,2))	AS [AverageBpm]
	FROM
		[Tracks] AS [TracksForBpm]
	WHERE
		[Bpm] IS NOT NULL
	GROUP BY
		[AlbumId]
),
[CTE_KeyDetails] AS
(
	--Common table expression to return the most common musical key of tracks on an album (where provided).
	SELECT TOP 1
		[Albums].[AlbumId]	AS [AlbumId],
		[Keys].[Name]		AS [MostFrequentKey]
	FROM
		[Albums]
	INNER JOIN
		[Tracks] ON [Tracks].[AlbumId] = [Albums].[AlbumId]
	INNER JOIN
		[Keys] ON [Tracks].[KeyId] = [Tracks].[KeyId]
	GROUP BY
		[Albums].[AlbumId],
		[Keys].[Name]
	ORDER BY
		COUNT([Tracks].[KeyId]) DESC
)
SELECT
	[Artists].[Name]											AS [ArtistName],
	[Albums].[Name]												AS [AlbumName],
	[Labels].[Name]												AS [LabelName],
	[CTE_AlbumTracksCount].[TrackCount]							AS [TrackCount],
	[CTE_BpmAverage].[AverageBpm]								AS [AverageBpm],
	ISNULL ([CTE_KeyDetails].[MostFrequentKey],'unknown')		AS [MostFrequentKey],
	(
		--Sub query to transform artist / album data into JSON.
		SELECT
			[ArtistsForJson].[Name]			AS [Artist.Name],
			[AlbumsForJson].[Name]			AS [Artist.Album.Name],
			[AlbumsForJson].[ReleaseDate]	AS [Artist.Album.ReleaseDate],
			[LabelsForJson].[Name]			AS [Artist.Album.Label],
			(
				--Sub query to transform album / track data into JSON.
				SELECT
					[TracksForJson].[TrackNumber]	AS [Number],
					[TracksForJson].[Name]			AS [Name],
					[KeysForJson].[Name]			AS [Key]
				FROM
					[Tracks] AS [TracksForJson]
				LEFT OUTER JOIN
					[Keys] AS [KeysForJson] ON [KeysForJson].[KeyId] = [TracksForJson].[KeyId] 
				WHERE
					[TracksForJson].[AlbumId] = [AlbumsForJson].[AlbumId]
				ORDER BY
					[TracksForJson].[TrackNumber]
				FOR JSON PATH
			) AS [Artist.Album.Tracks]
		FROM
			[Artists] AS [ArtistsForJson]
		INNER JOIN
			[Albums] AS [AlbumsForJson] ON [AlbumsForJson].[ArtistId] = [AlbumsForJson].[ArtistId]
		INNER JOIN
			[Labels] AS [LabelsForJson] ON [LabelsForJson].[LabelId] = [AlbumsForJson].[LabelId]
		WHERE
			[ArtistsForJson].[ArtistId] = [Artists].[ArtistId]
		AND
			[AlbumsForJson].[AlbumId] = [Albums].[AlbumId]
		FOR JSON PATH, ROOT ('ArtistAlbum')
	) AS [ArtistAlbumJson]
FROM
	[Artists]
LEFT OUTER JOIN
	[Albums] ON [Albums].[ArtistId] = [Artists].[ArtistId]
INNER JOIN
	[Labels] ON [Labels].[LabelId] = [Albums].[LabelId]
LEFT OUTER JOIN
	[CTE_AlbumTracksCount] ON [CTE_AlbumTracksCount].[AlbumId] = [Albums].[AlbumId]
LEFT OUTER JOIN
	[CTE_BpmAverage] ON [CTE_BpmAverage].[AlbumId] = [Albums].[AlbumId]
LEFT OUTER JOIN
	[CTE_KeyDetails] ON [CTE_KeyDetails].[AlbumId] = [Albums].[AlbumId];