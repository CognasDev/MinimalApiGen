IF (NOT EXISTS (SELECT 1 FROM [dbo].[Tracks])) BEGIN

	-- Global Communication - 76:14
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,1,'4:02',113);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,2,'14:31',115);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,3,'9:25',118);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,4,'9:39',106);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,5,'7:39',95);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,6,'0:54',91);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,7,'8:07',110);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,8,'5:23',110);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,9,'4:14',148);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (3,1,ABS(CHECKSUM(NEWID()) % 24) + 1,10,'12:18',115);

	-- Omni Trio - The Deepest Cut Vol. 1
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,1,'Renegade Snares (Foul Play VIP Mix)',159);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,2,'Living For The Future (FBD Project VIP Mix)',161);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,3,'Rollin'' Heights (More Strings Attached Mix)',159);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,4,'Mainline (95 Lick)',155);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,5,'Thru The Vibe',158);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,6,'Together',161);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,7,'Renegade Snares (Rob''s Reconstruction Mix)',158);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,8,'Shadowplay',158);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,9,'Alien Creed',132);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,10,'Feel Good (Original In Demand Mix)',154);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,11,'Living For The Future (Original Mix)',155);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (5,3,ABS(CHECKSUM(NEWID()) % 24) + 1,12,'Soul Promenade (Nookie Remix)',160);

	-- Omni Trio - The Haunted Science
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,1,'Astral Phase',172);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,2,'Nu Birth Of Cool (Rogue Unit Mix)',160);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,3,'Rhythm Methods',170);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,4,'Haunted Kind',98);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,5,'Trippin'' On Broken Beats (Carlito Mix)',161);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,6,'Who Are You (Aqua Sky Mix)',160);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,7,'The Elemental',166);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,8,'Serpent Navigators',161);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,9,'Trippin'' On Broken Beats (Alternative Take)',164);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,10,'Nu Birth Of Cool (Original 12" Mix)',160);
	INSERT INTO [dbo].[Tracks] ([AlbumId],[GenreId],[KeyId],[TrackNumber],[Name],[Bpm]) VALUES (6,3,ABS(CHECKSUM(NEWID()) % 24) + 1,11,'Who Are You (Original 12" Mix)',159);
	
END;