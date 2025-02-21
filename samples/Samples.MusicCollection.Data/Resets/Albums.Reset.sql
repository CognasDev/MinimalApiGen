IF (EXISTS (SELECT 1 FROM [dbo].[Albums])) BEGIN

	DELETE FROM [dbo].[Albums];

	DBCC CHECKIDENT ('[dbo].[Albums]', RESEED, 0);

END