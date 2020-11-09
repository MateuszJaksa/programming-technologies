using System.Collections.Generic;

namespace Data
{
    public class State
    {
        public State(Catalog catalog, string title)
        {
            Catalog = catalog;
            Title = title;
        }

        public Catalog Catalog
        { get; set; }

        public string Title
        { get; set; }

        public override bool Equals(object obj)
        {
            return obj is State state &&
                   this.Title == state.Title;
        }

        public override int GetHashCode()
        {
            return 434131217 + EqualityComparer<string>.Default.GetHashCode(Title);
        }
    }
}
