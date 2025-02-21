CREATE TABLE [dbo].[Labels]
(
	[LabelId] INT NOT NULL IDENTITY,
    [Name] VARCHAR(250) NOT NULL, 
    CONSTRAINT [PK_Labels] PRIMARY KEY ([LabelId])
)