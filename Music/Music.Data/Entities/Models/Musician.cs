using System.Collections.Generic;
using Music.Data.Enums;

namespace Music.Data.Entities.Models
{
    public class Musician
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nationalities Nationality { get; set; }
        public List<Album> AlbumsList { get; set; } = new List<Album>();

        public Musician(int id, string name, Nationalities nationality)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Nationality}";
        }
    }
}
