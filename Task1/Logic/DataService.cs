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

        public void ShowAllCatalogs()
        {
            List<Catalog> catalogs = _repository.GetAllCatalogs();
            for (int i = 0; i < catalogs.Count(); i++)
            {
                Console.WriteLine(catalogs[i]);
            }
        }

        public void ShowAllEvents()
        {
            List<Event> events = _repository.GetAllEvents();
            for (int i = 0; i < events.Count(); i++)
            {
                Console.WriteLine(events[i]);
            }
        }

        public void ShowAllStates()
        {
            List<State> states = _repository.GetAllStates();
            for (int i = 0; i < states.Count(); i++)
            {
                Console.WriteLine(states[i]);
            }
        }

        public void ShowAllUsers()
        {
            List<User> users = _repository.GetAllUsers();
            for (int i = 0; i < users.Count(); i++)
            {
                Console.WriteLine(users[i]);
            }
        }

        public static void Main(string[] args) {}        
    }
}
