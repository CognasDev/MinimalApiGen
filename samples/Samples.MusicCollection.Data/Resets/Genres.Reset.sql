IF (EXISTS (SELECT 1 FROM [dbo].[Genres])) BEGIN

	DELETE FROM [dbo].[Genres];

	DBCC CHECKIDENT ('[dbo].[Genres]', RESEED, 0);

END