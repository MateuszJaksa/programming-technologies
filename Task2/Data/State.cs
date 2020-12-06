using System.Collections.Generic;

namespace Data
{
    public class State : IState
    {
        public State(ICatalog catalog, int id)
        {
            Catalog = catalog;
            ID = id;
            IsBorrowed = false;
        }

        public ICatalog Catalog
        { get; set; }

        public int ID
        { get; set; }

        public bool IsBorrowed
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is State state &&
                   EqualityComparer<ICatalog>.Default.Equals(Catalog, state.Catalog) &&
                   ID == state.ID &&
                   IsBorrowed == state.IsBorrowed;
        }

        public override int GetHashCode()
        {
            int hashCode = -113272055;
            hashCode = hashCode * -1521134295 + EqualityComparer<ICatalog>.Default.GetHashCode(Catalog);
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + IsBorrowed.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"The state is connected to the book with an ID: {ID}";
        }
    }
}
