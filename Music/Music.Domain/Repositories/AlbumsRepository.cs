using System.Collections.Generic;
using Music.Data.Entities.Models;

namespace Music.Domain.Repositories
{
    public class AlbumsRepository
    {
        public static List<Album> AlbumsList = new List<Album>();

        public List<Album> GetAll() => AlbumsList;

        public void AddList(List<Album> albumsListToAdd)
        {
            foreach (var album in albumsListToAdd)
            {
                AlbumsList.Add(album);
            }
        }
    }
}
