IF (NOT EXISTS (SELECT 1 FROM [dbo].[Albums])) BEGIN

	INSERT INTO [dbo].[Albums] ([ArtistId],[GenreId],[LabelId],[Name],[ReleaseDate]) VALUES (1,1,1,'Dead Cities','1996-10-28');
	INSERT INTO [dbo].[Albums] ([ArtistId],[GenreId],[LabelId],[Name],[ReleaseDate]) VALUES (1,1,1,'Lifeforms','1994-05-23');
	INSERT INTO [dbo].[Albums] ([ArtistId],[GenreId],[LabelId],[Name],[ReleaseDate]) VALUES (2,1,2,'76:14','1994-06-01');
	INSERT INTO [dbo].[Albums] ([ArtistId],[GenreId],[LabelId],[Name],[ReleaseDate]) VALUES (2,1,2,'Remotion','1996-11-06');
	INSERT INTO [dbo].[Albums] ([ArtistId],[GenreId],[LabelId],[Name],[ReleaseDate]) VALUES (3,3,3,'The Deepest Cut Vol. 1','1995-01-30');
	INSERT INTO [dbo].[Albums] ([ArtistId],[LabelId],[Name],[ReleaseDate])			 VALUES (3,3,'The Haunted Science','1996-08-12');
	INSERT INTO [dbo].[Albums] ([ArtistId],[GenreId],[LabelId],[Name],[ReleaseDate]) VALUES (4,4,4,'Fallen Light','2010-10-25');

END;