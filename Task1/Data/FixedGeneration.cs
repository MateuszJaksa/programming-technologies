using System;
using Data;

namespace Tests
{
    public class FixedGeneration : IGeneration
    {
        public FixedGeneration() { }

        public void Fill(DataContext context)
        {
            User tempUser0 = new User("Tadeusz Chrostowski");
            User tempUser1 = new User("Janusz Domaniewski");
            User tempUser2 = new User("Andrzej Dunajewski");
            User tempUser3 = new User("Jan Haber");
            context.users.Add(tempUser0);
            context.users.Add(tempUser1);
            context.users.Add(tempUser2);
            context.users.Add(tempUser3);

            Catalog tempCatalog0 = new Catalog("Victor Hugo");
            Catalog tempCatalog1 = new Catalog("Ryszard Kapuscinski");
            Catalog tempCatalog2 = new Catalog("Isaac Asimov");
            Catalog tempCatalog3 = new Catalog("Howard Philips Lovecraft");
            context.catalogs.Add(tempCatalog0);
            context.catalogs.Add(tempCatalog1);
            context.catalogs.Add(tempCatalog2);
            context.catalogs.Add(tempCatalog3);

            State tempState0 = new State(tempCatalog0, "Les Miserables");
            State tempState1 = new State(tempCatalog1, "The Emperor");
            State tempState2 = new State(tempCatalog2, "Foundation");
            State tempState3 = new State(tempCatalog3, "The Call of Cthulhu");
            State tempState4 = new State(tempCatalog0, "La Legende des siecles");
            context.states.Add(tempState0);
            context.states.Add(tempState1);
            context.states.Add(tempState2);
            context.states.Add(tempState3);
            context.states.Add(tempState4);

            AbstractEvent tempEvent0 = new BorrowEvent(tempState0, tempUser0, DateTime.Now);
            AbstractEvent tempEvent1 = new BorrowEvent(tempState1, tempUser1, DateTime.Now);
            AbstractEvent tempEvent2 = new BorrowEvent(tempState2, tempUser2, DateTime.Now);
            AbstractEvent tempEvent3 = new ReturnEvent(tempState3, tempUser3, DateTime.Now);
            AbstractEvent tempEvent4 = new ReturnEvent(tempState4, tempUser0, new DateTime(2020, 10, 11, 12, 0, 0));
            AbstractEvent tempEvent5 = new ReturnEvent(tempState0, tempUser1, new DateTime(2020, 10, 11, 12, 0, 0));
            context.events.Add(tempEvent0);
            context.events.Add(tempEvent1);
            context.events.Add(tempEvent2);
            context.events.Add(tempEvent3);
            context.events.Add(tempEvent4);
            context.events.Add(tempEvent5);
        }
    }
}
