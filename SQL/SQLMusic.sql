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
	Duration INT NOT NULL,
)

CREATE TABLE AlbumSong (
	AlbumId INT FOREIGN KEY REFERENCES Album(Id),
	SongId INT FOREIGN KEY REFERENCES Song(Id)
)

/* Insert data */

INSERT INTO Musician ([Name], Nationality) VALUES (N'Mathers Marshall', N'American'),
												  (N'The Score', N'American'),
												  (N'TBF', N'Croatian')

INSERT INTO Album ([Name], MusicianId, ReleaseDate) VALUES (N'Kamikaze', 1, DATEADD(YEAR, -1, GETDATE())),
														   (N'The Slim Shady LP', 1, DATEADD(YEAR, -21, GETDATE())),
														   (N'Atlas', 2, DATEADD(YEAR, -2, GETDATE())),
														   (N'Unstoppable EP', 2, DATEADD(YEAR, -5, GETDATE())),
														   (N'Perpetuum Fritule', 3, DATEADD(YEAR, -8, GETDATE())),
														   (N'Pistaccio Metallic', 3, DATEADD(YEAR, -5, GETDATE()))

INSERT INTO Song ([Name], Duration) VALUES (N'Greatest', '226'),
										   (N'The Ringer', '337'),
										   (N'Lucky You', '277'),
										   (N'Bad Meets Evil', '269'),
										   (N'Not Alike', '287'),

										   (N'My Name Is', '268'),
										   (N'Brain Damage', '226'),
										   (N'Role Model', '205'),
										   (N'Rock Bottom', '214'),
										   (N'Bad Meets Evil', '253'),

										   (N'Legend', '189'),
										   (N'Unstoppable', '192'),
										   (N'Who I Am', '212'),
										   (N'Revolution', '231'),
										   (N'Shakedown', '268'),

										   (N'Unstoppable', '192'),
										   (N'Money Run Low', '185'),
										   (N'The Heat', '281'),
										   (N'Going Home', '258'),
										   (N'Where You Are', '286'),

										   (N'Malo San Maka', '231'),
										   (N'Nostalgična', '338'),
										   (N'Alles Gut', '281'),
										   (N'Smak Svita', '317'),
										   (N'Život je lijep', '238'),

										   (N'San', '293'),
										   (N'Uvik Kontra', '273'),
										   (N'Grad Spava', '305'),
										   (N'Pozitivan Stav', '263'),
										   (N'Smak Svita', '300')

INSERT INTO AlbumSong (AlbumId, SongId) VALUES (1, 1), (1, 2), (1, 3), (1, 4), (1, 5),
											   (2, 6), (2, 7), (2, 8), (2, 9), (2, 10),
											   (3, 11), (3, 12), (3, 13), (3, 14), (3, 15),
											   (4, 16), (4, 17), (4, 18), (4, 19), (4, 20),
											   (5, 21), (5, 22), (5, 23), (5, 24), (5, 25),
											   (6, 26), (6, 27), (6, 28), (6, 29), (6, 30)				   