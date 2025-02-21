CREATE TABLE [dbo].[Artists]
(
	[ArtistId] INT NOT NULL IDENTITY,
    [Name] VARCHAR(250) NOT NULL, 
    CONSTRAINT [PK_Artists] PRIMARY KEY ([ArtistId])
)