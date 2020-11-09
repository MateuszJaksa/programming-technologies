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

        public override string ToString()
        {
            return Genre + " written by " + Author;
        }
    }
}
