CREATE TABLE [dbo].[Genres]
(
	[GenreId] INT NOT NULL IDENTITY,
    [Name] VARCHAR(250) NOT NULL, 
    CONSTRAINT [PK_Genres] PRIMARY KEY ([GenreId])
)