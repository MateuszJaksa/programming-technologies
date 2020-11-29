using System;
using System.Linq;
using Data;

namespace Tests
{
    public class RandomGeneration : IGeneration
    {
        private static readonly Random RANDOM = new Random();
        private static readonly int FILLING_DEPTH = 8;
        private static readonly int USERNAME_LENGTH = 12;
        private static readonly int TITLE_LENGTH = 12;
        private static readonly int AUTHOR_LENGTH = 12;

        public RandomGeneration() { }

        private static string GetRandomString(int stringLength)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, stringLength)
              .Select(s => s[RANDOM.Next(s.Length)]).ToArray());
        }

        public static IDataContext Fill(IDataContext context)
        {
            for (int i = 0; i < FILLING_DEPTH; i++)
            {
                User tempUser = new User(GetRandomString(USERNAME_LENGTH));
                context.Users.Add(tempUser);
                Catalog tempCatalog = new Catalog(GetRandomString(TITLE_LENGTH), GetRandomString(AUTHOR_LENGTH));
                context.Catalogs.Add(tempCatalog);
                State tempState = new State(tempCatalog, RANDOM.Next());
                context.States.Add(tempState);
                context.Events.Add(new BorrowEvent(tempState, tempUser, DateTime.Now));
            }
            return context;
        }
    }
}
