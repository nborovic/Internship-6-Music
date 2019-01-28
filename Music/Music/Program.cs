using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
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
        }
    }
}
