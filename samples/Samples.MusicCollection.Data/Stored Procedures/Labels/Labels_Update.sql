CREATE PROCEDURE [dbo].[Labels_Update]
(
	@LabelId INT,
	@Name VARCHAR(250)
)
AS

SET NOCOUNT ON;

UPDATE [dbo].[Labels]
SET
	[Name] = @Name
WHERE
	[LabelId] = @LabelId;

EXEC [dbo].[Labels_SelectById] @LabelId;