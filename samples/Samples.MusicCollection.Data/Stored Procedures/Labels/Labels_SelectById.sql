CREATE PROCEDURE [dbo].[Labels_SelectById]
(
	@LabelId INT
)
AS

SET NOCOUNT ON;

SELECT
	[LabelId],
	[Name]
FROM
	[dbo].[Labels]
WHERE
	[LabelId] = @LabelId;