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

        public override string ToString()
        {
            return Title + " which is " + Catalog.ToString();
        }
    }
}
