using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
