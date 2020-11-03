using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;

namespace Logic
{
    public class DataService
    {
        private DataRepository _repository;

        public DataService(DataRepository repository)
        {
            this._repository = repository;
        }

        //public static void Main(string[] args) {}

        
    }
}
