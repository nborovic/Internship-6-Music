using System.Collections.Generic;
using Music.Data.Entities.Models;

namespace Music.Domain.Repositories
{
    public class AlbumsSongsRepository
    {
        public static List<AlbumSong> AlbumsSongsList = new List<AlbumSong>();

        public List<AlbumSong> GetAll() => AlbumsSongsList;

        public void AddList(List<AlbumSong> albumsSongsListToAdd)
        {
            foreach (var albumSong in albumsSongsListToAdd)
            {
                AlbumsSongsList.Add(albumSong);
            }
        }
    }
}
