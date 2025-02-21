IF (EXISTS (SELECT 1 FROM [dbo].[Artists])) BEGIN

	DELETE FROM [dbo].[Artists];

	DBCC CHECKIDENT ('[dbo].[Artists]', RESEED, 0);

END