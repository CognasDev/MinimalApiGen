IF (EXISTS (SELECT 1 FROM [dbo].[Keys])) BEGIN

	DELETE FROM [dbo].[Keys];

	DBCC CHECKIDENT ('[dbo].[Keys]', RESEED, 0);

END