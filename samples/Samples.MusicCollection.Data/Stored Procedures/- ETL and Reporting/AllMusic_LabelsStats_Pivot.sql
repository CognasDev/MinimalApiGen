CREATE PROCEDURE [AllMusic_LabelsStats_Pivot]

AS

SET NOCOUNT ON;

--Select album count statistic for given labels (AfterGlo, Dedicated, EBV and Moving Shadow)
SELECT
	'Album Count' AS [LabelStatistic],
	CAST([AfterGlo] AS VARCHAR(250))		AS [AfterGlo],
	CAST([Dedicated] AS VARCHAR(250))		AS [Dedicated],
	CAST([EBV] AS VARCHAR(250))				AS [EBV],
	CAST([Moving Shadow] AS VARCHAR(250))	AS [Moving Shadow]
FROM 
(
	SELECT
		[Labels].[Name],
		[AlbumId]
	FROM
		[Albums]
	INNER JOIN
		[Labels] ON [Labels].[LabelId] = [Albums].[LabelId]
) AS [AlbumCountByLabel]
PIVOT
(
	COUNT ([AlbumId])
	FOR [Name] IN
	(
		[AfterGlo],
		[Dedicated],
		[EBV],
		[Moving Shadow]
	)
) As [PIVOT_Label_AlbumCount]
UNION
--Select last release date for given labels (AfterGlo, Dedicated, EBV and Moving Shadow)
SELECT
	'Last Release',
	CONVERT(CHAR(10),[AfterGlo],126),
	CONVERT(CHAR(10),[Dedicated],126),
	CONVERT(CHAR(10),[EBV],126),
	CONVERT(CHAR(10),[Moving Shadow],126)
FROM 
(
	SELECT
		[Labels].[Name],
		[ReleaseDate]
	FROM
		[Albums]
	INNER JOIN
		[Labels] ON [Labels].[LabelId] = [Albums].[LabelId]
) AS [ReleaseDateByLabel]
PIVOT
(
	MAX ([ReleaseDate])
	FOR [Name] IN
	(
		[AfterGlo],
		[Dedicated],
		[EBV],
		[Moving Shadow]
	)
) As [PIVOT_Label_LastRelease]