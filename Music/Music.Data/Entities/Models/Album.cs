using System;

namespace Music.Data.Entities.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int MusicianId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            return $"{Id} - {MusicianId} - {Name} - {ReleaseDate:d}";
        }
    }
}