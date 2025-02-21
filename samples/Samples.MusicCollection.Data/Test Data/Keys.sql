IF (NOT EXISTS (SELECT 1 FROM [dbo].[Keys])) BEGIN

	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('1A','A flat minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('1B','B major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('2A','E flat minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('2B','F sharp major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('3A','B flat minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('3B','D flat major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('4A','F minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('4B','A flat major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('5A','C minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('5B','E flat major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('6A','G minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('6B','B flat major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('7A','D minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('7B','F major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('8A','A minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('8B','C major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('9A','E minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('9B','G major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('10A','B minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('10B','D major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('11A','F sharp minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('11B','A major');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('12A','D flat minor');
	INSERT INTO [dbo].[Keys] ([CamelotCode],[Name]) VALUES ('12B','E major');

END;