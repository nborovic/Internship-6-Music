using Music.Data.Enums;

namespace Music.Data.Entities.Models
{
    public class Musician
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nationalities Nationality { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Nationality}";
        }
    }
}
