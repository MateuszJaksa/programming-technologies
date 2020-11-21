namespace Data
{
    public interface ICatalog
    {
        string Author
        { get; set; }

        string Title
        { get; set; }

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}
