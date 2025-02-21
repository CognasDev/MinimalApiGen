CREATE PROCEDURE [dbo].[Labels_Select]

AS

SET NOCOUNT ON;

SELECT
	[LabelId],
	[Name]
FROM
	[dbo].[Labels];