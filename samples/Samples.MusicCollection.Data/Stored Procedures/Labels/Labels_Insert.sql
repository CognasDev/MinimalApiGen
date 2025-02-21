CREATE PROCEDURE [dbo].[Labels_Insert]
(
	@LabelId INT,
	@Name VARCHAR(250)
)
AS

SET NOCOUNT ON;

INSERT INTO [dbo].[Labels]
(
	[Name]
)
VALUES
(
	@Name
);

DECLARE @newLabelId INT;
SELECT @newLabelId = CAST(SCOPE_IDENTITY() AS INT);

EXEC [dbo].[Labels_SelectById] @newLabelId;