using System;
using Data;

namespace Tests
{
    public class FixedGeneration : IGeneration
    {
        public FixedGeneration() { }

        public static IDataContext Fill(IDataContext context)
        {
            User tempUser0 = new User("Tadeusz Chrostowski");
            User tempUser1 = new User("Janusz Domaniewski");
            User tempUser2 = new User("Andrzej Dunajewski");
            User tempUser3 = new User("Jan Haber");
            context.Users.Add(tempUser0);
            context.Users.Add(tempUser1);
            context.Users.Add(tempUser2);
            context.Users.Add(tempUser3);

            Catalog tempCatalog0 = new Catalog("Les Miserables", "Victor Hugo");
            Catalog tempCatalog1 = new Catalog("The Emperor", "Ryszard Kapuscinski");
            Catalog tempCatalog2 = new Catalog("Foundation", "Isaac Asimov");
            Catalog tempCatalog3 = new Catalog("The Call of Cthulhu", "Howard Philips Lovecraft");
            context.Catalogs.Add(tempCatalog0);
            context.Catalogs.Add(tempCatalog1);
            context.Catalogs.Add(tempCatalog2);
            context.Catalogs.Add(tempCatalog3);

            State tempState0 = new State(tempCatalog0, 11);
            State tempState1 = new State(tempCatalog1, 22);
            State tempState2 = new State(tempCatalog2, 33);
            State tempState3 = new State(tempCatalog3, 44);
            State tempState4 = new State(tempCatalog0, 55);
            context.States.Add(tempState0);
            context.States.Add(tempState1);
            context.States.Add(tempState2);
            context.States.Add(tempState3);
            context.States.Add(tempState4);

            AbstractEvent tempEvent0 = new BorrowEvent(tempState0, tempUser0, DateTime.Now);
            AbstractEvent tempEvent1 = new BorrowEvent(tempState1, tempUser1, DateTime.Now);
            AbstractEvent tempEvent2 = new BorrowEvent(tempState2, tempUser0, new DateTime(2020, 10, 11, 12, 0, 0));
            AbstractEvent tempEvent3 = new BorrowEvent(tempState3, tempUser1, new DateTime(2020, 10, 11, 12, 0, 0));
            AbstractEvent tempEvent4 = new ReturnEvent(tempState0, tempUser0, DateTime.Now);
            context.Events.Add(tempEvent0);
            context.Events.Add(tempEvent1);
            context.Events.Add(tempEvent2);
            context.Events.Add(tempEvent3);
            context.Events.Add(tempEvent4);

            return context;
        }
    }
}
