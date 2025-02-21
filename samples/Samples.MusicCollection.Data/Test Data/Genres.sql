IF (NOT EXISTS (SELECT 1 FROM [dbo].[Genres])) BEGIN

	INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Ambient');
	INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Breakbeat');
	INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Drum & Bass');
	INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Dubstep');
	INSERT INTO [dbo].[Genres] ([Name]) VALUES ('House');
	INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Jazz');

END;