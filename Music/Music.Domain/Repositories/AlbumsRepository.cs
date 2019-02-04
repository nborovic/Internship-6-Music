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

        public void CreateRelations()
        {
            var albumsSongsRepository = new AlbumsSongsRepository().GetAll();
            var songsRepository = new SongsRepository().GetAll();

            foreach (var albumSong in albumsSongsRepository)
                foreach (var song in songsRepository)
                    foreach (var album in AlbumsList)
                        if (song.Id == albumSong.SongId && album.Id == albumSong.AlbumId)
                        {
                            song.AlbumsList.Add(album);
                            album.SongsList.Add(song);
                        }
        }
    }
}