IF (NOT EXISTS (SELECT 1 FROM [dbo].[Labels])) BEGIN

	INSERT INTO [dbo].[Labels] ([Name]) VALUES ('EBV');
	INSERT INTO [dbo].[Labels] ([Name]) VALUES ('Dedicated');
	INSERT INTO [dbo].[Labels] ([Name]) VALUES ('Moving Shadow');
	INSERT INTO [dbo].[Labels] ([Name]) VALUES ('Afterglo');

END;