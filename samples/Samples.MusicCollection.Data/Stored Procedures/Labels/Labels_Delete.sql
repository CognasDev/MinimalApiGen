CREATE PROCEDURE [dbo].[Labels_Delete]
(
	@LabelId INT
)
AS

SET NOCOUNT ON;

DELETE FROM
	[dbo].[Labels]
WHERE
	[LabelId] = @LabelId;

SELECT @@ROWCOUNT;