using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class State
    {
        private Catalog _catalog;
        private string _title;

        public State(Catalog catalog, string title)
        {
            this._catalog = catalog;
            this._title = title;
        }

        public Catalog Catalog
        {
            get => _catalog;
            set => this._catalog = value;
        }

        public string Title
        {
            get => _title;
            set => this._title = value;
        }

        public override string ToString()
        {
            return _title + " which is " + _catalog.ToString();
        }
    }
}
