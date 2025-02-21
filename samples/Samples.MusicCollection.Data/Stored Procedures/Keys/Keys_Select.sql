CREATE PROCEDURE [dbo].[Keys_Select]

AS

SET NOCOUNT ON;

SELECT
	[KeyId],
	[CamelotCode],
	[Name]
FROM
	[dbo].[Keys];