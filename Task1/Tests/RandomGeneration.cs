using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Tests
{
    class RandomGeneration : IGeneration
    {
        private static readonly Random RANDOM = new Random();
        private static readonly int FILLING_DEPTH = 8;
        private static readonly int USERNAME_LENGTH = 12;
        private static readonly int TITLE_LENGTH = 12;
        private static readonly int AUTHOR_LENGTH = 8;
        private static readonly int GENRE_LENGTH = 12;

        RandomGeneration() { }

        private static string GetRandomString(int stringLength)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, stringLength)
              .Select(s => s[RANDOM.Next(s.Length)]).ToArray());
        }

        public void Fill(DataContext context)
        {
            for (int i = 0; i < FILLING_DEPTH; i++)
            {
                User tempUser = new User(GetRandomString(USERNAME_LENGTH));
                context.users.Add(tempUser);
                Catalog tempCatalog = new Catalog(GetRandomString(AUTHOR_LENGTH), GetRandomString(GENRE_LENGTH));
                context.catalogs.Add(tempCatalog);
                State tempState = new State(tempCatalog, GetRandomString(TITLE_LENGTH));
                context.states.Add(tempState);
                context.events.Add(new Event(tempState, tempUser, DateTime.Now));
            }
        }
    }
}
