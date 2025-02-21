CREATE TABLE [dbo].[Albums]
(
	[AlbumId] INT NOT NULL IDENTITY,
    [ArtistId] INT NOT NULL, 
    [GenreId] INT NULL,
    [LabelId] INT NOT NULL, 
    [Name] VARCHAR(250) NOT NULL, 
    [ReleaseDate] SMALLDATETIME NOT NULL, 
    CONSTRAINT [PK_Albums] PRIMARY KEY ([AlbumId]), 
    CONSTRAINT [FK_Albums_Artists] FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artists]  ([ArtistId]),
    CONSTRAINT [FK_Albums_Genres]  FOREIGN KEY ([GenreId])  REFERENCES [dbo].[Genres]   ([GenreId]),
    CONSTRAINT [FK_Albums_Labels]  FOREIGN KEY ([LabelId])  REFERENCES [dbo].[Labels]   ([LabelId])
)
GO

CREATE INDEX [IX_Albums_ArtistId] ON [dbo].[Albums] ([ArtistId])
GO

CREATE INDEX [IX_Albums_GenreId] ON [dbo].[Albums] ([GenreId])
GO

CREATE INDEX [IX_Albums_LabelId] ON [dbo].[Albums] ([LabelId])
GO