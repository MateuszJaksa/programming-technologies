using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Catalog
    {
        private string _author;
        private string _genre;

        public Catalog(string author, string genre)
        {
            this._author = author;
            this._genre = genre;
        }

        public string Author
        {
            get => _author;
            set => this._author = value;
        }

        public string Genre
        {
            get => _genre;
            set => this._genre = value;
        }

        public override string ToString()
        {
            return _genre + " written by " + _author;
        }
    }
}
