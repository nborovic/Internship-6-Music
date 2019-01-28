using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Music.Data;
using Music.Data.Entities.Models;
using Music.Domain.Repositories;

namespace Music
{
    class Program
    {
        static void Main(string[] args)
        {
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

            var orderedMusiciansList = musiciansList.OrderBy(musician => musician.Name);

            Console.WriteLine("All musicians ordered by name: ");
            foreach (var musician in orderedMusiciansList)
            {
                Console.WriteLine(musician.ToString());
            }

            // Task 2

            Console.Write("\nChoose nationality (0-1): ");
            var selectedNationality = (Nationalities)int.Parse(Console.ReadLine());
            var musiciansOfSelectedNationality = musiciansList
                .Where(musician => musician.Nationality == selectedNationality).OrderBy(musician => musician.Id);

            Console.WriteLine($"Musicians of {selectedNationality.ToString()} nationality: ");
            foreach (var musician in musiciansOfSelectedNationality)
            {
                Console.WriteLine(musician.ToString());
            }

            // Task 3

            var albumsMusician = from album in albumsList
                                 join musician in musiciansList on album.MusicianId equals musician.Id
                                 select new { ReleaseDate = album.ReleaseDate, album.Name, Musician = musician.Name };

            var albumsMusicianYears = from album in albumsMusician orderby album.ReleaseDate group album by album.ReleaseDate;

            foreach (var year in albumsMusicianYears)
            {
                Console.WriteLine($"\n{year.Key:d}: ");
                foreach (var album in year)
                {
                    Console.WriteLine($"{album.Musician} - {album.Name}");
                }
            }

            // Task 4

            Console.Write("Input album name: ");
            var selectedText = Console.ReadLine();
            var albumsContainingSelectedText =
                albumsList.Where(album => album.Name.Contains(selectedText)).OrderBy(album => album.Id);

            foreach (var album in albumsContainingSelectedText)
            {
                Console.WriteLine(album.ToString());
            }
        }
    }
}
