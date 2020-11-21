namespace Data
{
    public interface IUser
    {
        string Username
        { get; set; }

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}
