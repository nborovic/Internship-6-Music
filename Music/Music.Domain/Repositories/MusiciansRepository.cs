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
    }
}
