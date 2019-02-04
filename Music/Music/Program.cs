using System;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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
                    
            musiciansRepository.CreateRelations();
            albumsRepository.CreateRelations();

            // Task 1

            NewTask("Task 1");

            Console.WriteLine("All musicians ordered by name: ");
            musiciansRepository.GetAll()
                .OrderBy(musician => musician.Name)
                .ToList()
                .ForEach(musician => Console.WriteLine(musician.ToString()));

            // Task 2

            NewTask("Task 2");

            Console.Write("Choose nationality (0-1): ");
            var selectedNationality = (Nationalities)int.Parse(Console.ReadLine());

            musiciansRepository.GetAll()
                .Where(musician => musician.Nationality == selectedNationality)
                .ToList()
                .ForEach(musician => Console.WriteLine(musician.ToString()));
            
            // Task 3

            NewTask("Task 3");

            var groupedAlbumsRepository = albumsRepository.GetAll()
                .GroupBy(album => album.ReleaseDate.Year)
                .ToList();

            groupedAlbumsRepository.ForEach(albumGroup => {
                Console.WriteLine($"{albumGroup.Key}:");
                albumGroup.ToList().ForEach(album => Console.WriteLine(album.ToString()));
            });           

            // Task 4

            NewTask("Task 4");

            Console.Write("Input album name: ");
            var selectedText = Console.ReadLine();
            Console.WriteLine("All albums containing selected text: ");
            albumsRepository.GetAll()
                .Where(album => selectedText != null && album.Name.Contains(selectedText))
                .ToList()
                .ForEach(album => Console.WriteLine(album.ToString()));

            // Task 5

            NewTask("Task 5");

            Console.WriteLine("Duration of all albums: ");
            albumsRepository.GetAll()
                .ForEach(album => Console.WriteLine($"{album.Name}: {album.Duration() / 60} minutes and {album.Duration() % 60} seconds"));

            // Task 6

            NewTask("Task 6");

            Console.Write("Input name of the song: ");
            var selectedSong = Console.ReadLine();
            var selectedSongAsSong = songsRepository.GetAll().FirstOrDefault(song => selectedSong != null && song.Name.Contains(selectedSong));

            Console.WriteLine("All albums with selected song: ");
            albumsRepository.GetAll()
                .Where(album => album.SongsList.Contains(selectedSongAsSong))
                .ToList()
                .ForEach(album => Console.WriteLine(album.ToString()));

            // Task 7

            NewTask("Task 7");

            Console.Write("Input musician name: ");
            var selectedMusician = Console.ReadLine();
            Console.Write("Input release year: ");
            var selectedReleaseYear = int.Parse(Console.ReadLine());

            albumsRepository.GetAll()
                .Where(album => selectedMusician != null && (album.Musician.Name.Contains(selectedMusician) && album.ReleaseDate.Year > selectedReleaseYear))
                .ToList()
                .ForEach(album => album.SongsList.ForEach(song => Console.WriteLine(song.ToString())));

        }

        public static void NewTask(string task)
        {
            Console.WriteLine($"\n{task}\n----------------------------------------------------\n");
        }
    }
}