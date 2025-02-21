IF (EXISTS (SELECT 1 FROM [dbo].[Labels])) BEGIN

	DELETE FROM [dbo].[Labels];

	DBCC CHECKIDENT ('[dbo].[Labels]', RESEED, 0);

END