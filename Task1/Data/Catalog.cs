using System.Collections.Generic;

namespace Data
{
    public class Catalog
    {
        public Catalog(string author, string genre)
        {
            Author = author;
            Genre = genre;
        }

        public string Author
        { get; set; }

        public string Genre
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Catalog catalog &&
                   this.Author == catalog.Author &&
                   this.Genre == catalog.Genre;
        }

        public override int GetHashCode()
        {
            int hashCode = -1994181324;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genre);
            return hashCode;
        }

        public override string ToString()
        {
            return $"The catalog consists of {Genre} written by {Author}";
        }
    }
}
