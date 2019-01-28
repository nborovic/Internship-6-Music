using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Data.Entities.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int MusicianId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
