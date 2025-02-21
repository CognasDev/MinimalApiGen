IF (NOT EXISTS (SELECT 1 FROM [dbo].[Artists])) BEGIN

	INSERT INTO [dbo].[Artists] ([Name]) VALUES ('Future Sound Of London');
	INSERT INTO [dbo].[Artists] ([Name]) VALUES ('Global Communication');
	INSERT INTO [dbo].[Artists] ([Name]) VALUES ('Omni Trio');
	INSERT INTO [dbo].[Artists] ([Name]) VALUES ('Phaeleh');

END;