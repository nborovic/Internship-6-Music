using System.Collections.Generic;
using Music.Data.Entities.Models;

namespace Music.Domain.Repositories
{
    public class SongsRepository
    {
        public static List<Song> SongsList = new List<Song>();

        public List<Song> GetAll() => SongsList;

        public void AddList(List<Song> songsListToAdd)
        {
            foreach (var song in songsListToAdd)
            {
                SongsList.Add(song);
            }
        }
    }
}
