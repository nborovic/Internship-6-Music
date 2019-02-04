using System.Collections.Generic;

namespace Music.Data.Entities.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public List<Album> AlbumsList { get; set; } = new List<Album>();

        public Song(int id, string name, int duration)
        {
            Id = id;
            Name = name;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Duration}";
        }
    }
}