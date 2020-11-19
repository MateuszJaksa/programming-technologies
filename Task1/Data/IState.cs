namespace Data
{
    public interface IState
    {
        ICatalog Catalog
        { get; set; }

        int ID
        { get; set; }

        bool IsBorrowed
        { get; set; }

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}
