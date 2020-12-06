using System.Collections.Generic;

namespace Data
{
    public class Catalog : ICatalog
    {
        public Catalog(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public string Author
        { get; set; }

        public string Title
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Catalog catalog &&
                   Author == catalog.Author &&
                   Title == catalog.Title;
        }

        public override int GetHashCode()
        {
            int hashCode = 507744655;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            return hashCode;
        }

        public override string ToString()
        {
            return $"The catalog {Title} written by {Author}";
        }
    }
}
