/*
	MUSIC
*/

CREATE DATABASE Music


/* Tables */

CREATE TABLE Musician (
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Nationality NVARCHAR(30) NOT NULL
)

CREATE TABLE Album (
	Id INT IDENTITY PRIMARY KEY,
	MusicianId INT FOREIGN KEY REFERENCES Musician(Id),
	[Name] NVARCHAR(35) NOT NULL,
	ReleaseDate DATETIME2 NOT NULL,
)

CREATE TABLE Song (
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(35) NOT NULL,
	Duration NVARCHAR(4) NOT NULL,
)

CREATE TABLE AlbumSong (
	AlbumId INT FOREIGN KEY REFERENCES Album(Id),
	SongId INT FOREIGN KEY REFERENCES Song(Id)
)

/* Insert data */

INSERT INTO Musician ([Name], Nationality) VALUES (N'Marshall Mathers', N'American'),
												  (N'The Score', N'American'),
												  (N'TBF', N'Croatian')

INSERT INTO Album ([Name], MusicianId, ReleaseDate) VALUES (N'Kamikaze', 1, DATEADD(YEAR, -1, GETDATE())),
														   (N'The Slim Shady LP', 1, DATEADD(YEAR, -21, GETDATE())),
														   (N'Atlas', 2, DATEADD(YEAR, -2, GETDATE())),
														   (N'Unstoppable EP', 2, DATEADD(YEAR, -4, GETDATE())),
														   (N'Perpetuum Fritule', 3, DATEADD(YEAR, -8, GETDATE())),
														   (N'Pistaccio Metallic', 3, DATEADD(YEAR, -7, GETDATE()))

INSERT INTO Song ([Name], Duration) VALUES (N'Greatest', '3:46'),
										   (N'The Ringer', '5:37'),
										   (N'Lucky You', '4:37'),
										   (N'Venom', '4:29'),
										   (N'Not Alike', '4:48'),

										   (N'My Name Is', '4:28'),
										   (N'Brain Damage', '3:46'),
										   (N'Role Model', '3:25'),
										   (N'Rock Bottom', '3:34'),
										   (N'Bad Meets Evil', '4:13'),

										   (N'Legend', '3:09'),
										   (N'Unstoppable', '3:12'),
										   (N'Who I Am', '3:32'),
										   (N'Revolution', '3:51'),
										   (N'Shakedown', '4:28'),

										   (N'Unstoppable', '3:12'),
										   (N'Money Run Low', '3:05'),
										   (N'The Heat', '3:41'),
										   (N'Going Home', '3:18'),
										   (N'Where You Are', '3:46'),

										   (N'Malo San Maka', '3:51'),
										   (N'Nostalgična', '5:38'),
										   (N'Alles Gut', '4:41'),
										   (N'Smak Svita', '6:12'),
										   (N'Život je lijep', '3:58'),

										   (N'San', '4:53'),
										   (N'Uvik Kontra', '4:34'),
										   (N'Grad Spava', '5:05'),
										   (N'Pozitivan Stav', '4:23'),
										   (N'Vrag', '5:00')

INSERT INTO AlbumSong (AlbumId, SongId) VALUES (1, 1), (1, 2), (1, 3), (1, 4), (1, 5),
											   (2, 6), (2, 7), (2, 8), (2, 9), (2, 10),
											   (3, 11), (3, 12), (3, 13), (3, 14), (3, 15),
											   (4, 16), (4, 17), (4, 18), (4, 19), (4, 20),
											   (5, 21), (5, 22), (5, 23), (5, 24), (5, 25),
											   (6, 26), (6, 27), (6, 28), (6, 29), (6, 30)
												


														   