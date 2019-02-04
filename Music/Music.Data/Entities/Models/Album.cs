using System;
using System.Collections.Generic;
using System.Linq;

namespace Music.Data.Entities.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int MusicianId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Song> SongsList { get; set; } = new List<Song>();
        public Musician Musician { get; set; }

        public Album(int id, int musicianId, string name, DateTime releaseDate)
        {
            Id = id;
            MusicianId = musicianId;
            Name = name;
            ReleaseDate = releaseDate;
        }

        public int Duration() => SongsList.Sum(song => song.Duration);

        public override string ToString()
        {
            return $"{Id} - {Name} - {Musician.Name} - {ReleaseDate:d}";
        }
    }
}