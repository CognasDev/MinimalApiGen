CREATE TABLE [dbo].[Tracks]
(
	[TrackId] INT NOT NULL IDENTITY,
    [AlbumId] INT NOT NULL,
    [GenreId] INT NOT NULL,
    [KeyId] INT NULL,
    [TrackNumber] INT NOT NULL, 
    [Name] VARCHAR(250) NOT NULL, 
    [Bpm] FLOAT NULL, 
    CONSTRAINT [PK_Tracks] PRIMARY KEY ([TrackId]), 
    CONSTRAINT [FK_Tracks_Albums]   FOREIGN KEY ([AlbumId])     REFERENCES [Albums]     ([AlbumId]),
    CONSTRAINT [FK_Tracks_Genres]   FOREIGN KEY ([GenreId])     REFERENCES [Genres]     ([GenreId]),
    CONSTRAINT [FK_Tracks_Keys]     FOREIGN KEY ([KeyId])       REFERENCES [Keys]       ([KeyId])
)
GO

CREATE INDEX [IX_Tracks_AlbumId] ON [dbo].[Tracks] ([AlbumId])
GO

CREATE INDEX [IX_Tracks_GenreId] ON [dbo].[Tracks] ([GenreId])
GO

CREATE INDEX [IX_Tracks_KeyId] ON [dbo].[Tracks] ([KeyId])
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Tracks_AlbumId_TrackNumber] ON [dbo].[Tracks] ([AlbumId], [TrackNumber]);
GO