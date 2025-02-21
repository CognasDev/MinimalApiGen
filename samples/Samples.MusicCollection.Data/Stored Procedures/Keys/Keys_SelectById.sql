CREATE PROCEDURE [dbo].[Keys_SelectById]
(
	@KeyId INT
)
AS

SET NOCOUNT ON;

SELECT
	[KeyId],
	[CamelotCode],
	[Name]
FROM
	[dbo].[Keys]
WHERE
	[KeyId] = @KeyId;