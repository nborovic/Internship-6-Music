using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Music.Data.Entities.Models;
using Music.Data.Enums;
using Music.Domain.Repositories;

namespace Music.Presentation
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Connecting to database and pulling data

            var musiciansRepository = new MusiciansRepository();
            var albumsRepository = new AlbumsRepository();
            var songsRepository = new SongsRepository();
            var albumsSongsRepository = new AlbumsSongsRepository();

            const string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Music;Integrated Security=true;MultipleActiveResultSets=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                musiciansRepository.AddList(connection.Query<Musician>("SELECT * FROM Musician").ToList());
                albumsRepository.AddList(connection.Query<Album>("SELECT * FROM Album").ToList());
                songsRepository.AddList(connection.Query<Song>("SELECT * FROM Song").ToList());
                albumsSongsRepository.AddList(connection.Query<AlbumSong>("SELECT * FROM AlbumSong").ToList());
            }

            var musiciansList = musiciansRepository.GetAll();
            var albumsList = albumsRepository.GetAll();
            var songsList = songsRepository.GetAll();
            var albumsSongsList = albumsSongsRepository.GetAll();

            // Task 1

            NewTask("Task 1");

            var orderedMusiciansList = musiciansList.OrderBy(musician => musician.Name);

            Console.WriteLine("All musicians ordered by name: ");
            foreach (var musician in orderedMusiciansList)
            {
                Console.WriteLine(musician.ToString());
            }

            // Task 2

            NewTask("Task 2");

            Console.Write("Choose nationality (0-1): ");
            var selectedNationality = (Nationalities)int.Parse(Console.ReadLine());

            var musiciansOfSelectedNationality = musiciansList
                .Where(musician => musician.Nationality == selectedNationality).OrderBy(musician => musician.Id);

            Console.WriteLine($"Musicians of {selectedNationality.ToString()} nationality: ");
            foreach (var musician in musiciansOfSelectedNationality)
            {
                Console.WriteLine(musician.ToString());
            }

            // Task 3

            NewTask("Task 3");

            var albumsMusician = from album in albumsList
                                 join musician in musiciansList on album.MusicianId equals musician.Id
                                 select new { Release = album.ReleaseDate, album.Name, Musician = musician.Name };

            var albumsGroupedByRealease = from album in albumsMusician orderby album.Release group album by album.Release;

            foreach (var year in albumsGroupedByRealease)
            {
                Console.WriteLine($"{year.Key:d}: ");
                foreach (var album in year)
                {
                    Console.WriteLine($"{album.Musician} - {album.Name}");
                }
            }

            // Task 4

            NewTask("Task 4");

            Console.Write("Input album name: ");
            var selectedText = Console.ReadLine();
            var albumsContainingSelectedText =
                albumsList.Where(album => selectedText != null && album.Name.Contains(selectedText)).OrderBy(album => album.Id);

            Console.WriteLine("All albums containing selected text: ");
            foreach (var album in albumsContainingSelectedText)
            {
                Console.WriteLine(album.ToString());
            }

            if (!albumsContainingSelectedText.Any())
                Console.WriteLine($"No albums containing '{selectedText}'!");

            // Task 5

            NewTask("Task 5");

            Console.WriteLine("Duration of all albums: ");
            var albumsSongs = from album in albumsList
                join albumSong in albumsSongsList on album.Id equals albumSong.AlbumId
                join song in songsList on albumSong.SongId equals song.Id
                select new {AlbumName = album.Name, AlbumId = album.Id, SongDuration = song.Duration};

            var albumsGroupedByName = from album in albumsSongs orderby album.AlbumName group album by album.AlbumName;

            foreach (var albumSong in albumsGroupedByName)
            {
                var albumDuration = 0;
                Console.Write($"{albumSong.Key} duration: ");
                albumDuration += albumSong.Sum(song => song.SongDuration);
                Console.WriteLine($"{albumDuration / 60}:{albumDuration % 60} minutes");
            }

            // Task 6

            NewTask("Task 6");

            Console.Write("Input name of the song: ");
            var selectedSong = Console.ReadLine();
            var allAlbumsContainingSelectedSong = from album in albumsList
                join albumSong in albumsSongsList on album.Id equals albumSong.AlbumId
                join song in songsList on albumSong.SongId equals song.Id
                where selectedSong != null && song.Name.Contains(selectedSong)
                select new {SongName = song.Name, AlbumId = album.Id, AlbumMusicianId = album.MusicianId, AlbumName = album.Name, AlbumRelease = album.ReleaseDate};

            Console.WriteLine("All albums with selected song: ");

            var albumsContainingSelectedSong = allAlbumsContainingSelectedSong.ToList();

            foreach (var album in albumsContainingSelectedSong)
            {
                Console.WriteLine($"{album.SongName} - {album.AlbumId} - {album.AlbumMusicianId} - {album.AlbumName} - {album.AlbumRelease:d}");
            }

            if (!albumsContainingSelectedSong.Any())
                Console.WriteLine($"No albums containing '{selectedSong}'!");

            // Task 7

            NewTask("Task 7");

            Console.Write("Input musician name: ");
            var selectedMusician = Console.ReadLine();
            Console.Write("Input release year: ");
            var selectedReleaseYear = int.Parse(Console.ReadLine());

            var allSongsOfSelectedMusicianAfterSelectedYear = from album in albumsList
                join albumSong in albumsSongsList on album.Id equals albumSong.AlbumId
                where album.ReleaseDate.Year >= selectedReleaseYear
                join song in songsList on albumSong.SongId equals song.Id
                join musician in musiciansList on album.MusicianId equals musician.Id
                where selectedMusician != null && musician.Name.Contains(selectedMusician)
                select new {MusicianName = musician.Name, AlbumName = album.Name, SongName = song.Name, ReleaseYear = album.ReleaseDate};

            var songsGroupedByAlbums = from song in allSongsOfSelectedMusicianAfterSelectedYear
                orderby song.AlbumName
                group song by song.AlbumName; 

            foreach (var group in songsGroupedByAlbums)
            {
                Console.WriteLine($"\n{group.Key}: ");
                foreach (var song in group)
                    Console.WriteLine($"{song.SongName} - {song.MusicianName} - {song.ReleaseYear:d}");
            }

            if (!allSongsOfSelectedMusicianAfterSelectedYear.Any())
                Console.WriteLine($"No songs of '{selectedMusician}' after the year of '{selectedReleaseYear}'!");
        }

        public static void NewTask(string task)
        {
            Console.WriteLine($"\n{task}\n----------------------------------------------------\n");
        }
    }
}