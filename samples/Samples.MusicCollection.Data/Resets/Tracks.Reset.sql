IF (EXISTS (SELECT 1 FROM [dbo].[Tracks])) BEGIN

	DELETE FROM [dbo].[Tracks];

	DBCC CHECKIDENT ('[dbo].[Tracks]', RESEED, 0);

END