using System.Collections.Generic;

namespace Data
{
    public class State
    {
        public State(Catalog catalog, string title)
        {
            Catalog = catalog;
            Title = title;
            IsBorrowed = false;
        }

        public Catalog Catalog
        { get; set; }

        public string Title
        { get; set; }

        public bool IsBorrowed
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is State state &&
                   Title == state.Title &&
                   IsBorrowed == state.IsBorrowed;
        }

        public override int GetHashCode()
        {
            int hashCode = -1443766054;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + IsBorrowed.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"The state is connected to the book titled {Title}";
        }
    }
}
