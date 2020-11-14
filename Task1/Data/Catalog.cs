using System.Collections.Generic;

namespace Data
{
    public class Catalog
    {
        public Catalog(string author)
        {
            Author = author;
        }

        public string Author
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Catalog catalog &&
                   this.Author == catalog.Author;
        }

        public override int GetHashCode()
        {
            int initialSeed = -1994181324;
            return initialSeed * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
        }

        public override string ToString()
        {
            return $"The catalog is connected to {Author}";
        }
    }
}
