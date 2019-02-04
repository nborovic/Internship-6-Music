using System.Collections.Generic;
using Music.Data.Entities.Models;

namespace Music.Domain.Repositories
{
    public class MusiciansRepository
    {
        public static List<Musician> MusiciansList = new List<Musician>();

        public List<Musician> GetAll() => MusiciansList;

        public void AddList(List<Musician> musiciansListToAdd)
        {
            foreach (var musician in musiciansListToAdd)
            {
                MusiciansList.Add(musician);
            }
        }

        public void CreateRelations()
        {
            var albumsRepository = new AlbumsRepository().GetAll();

            foreach (var musician in MusiciansList)
                foreach (var album in albumsRepository)
                    if (album.MusicianId == musician.Id)
                    {
                        musician.AlbumsList.Add(album);
                        album.Musician = musician;
                    }
        }
    }
}
