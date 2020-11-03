using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        private string _userName;

        public User(string userName)
        {
            this._userName = userName;
        }

        public string UserName
        {
            get => _userName;
            set => this._userName = value;
        }

        public override string ToString()
        {
            return "Our user " + _userName;
        }
    }
}
