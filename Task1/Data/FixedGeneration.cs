using System;
using Data;

namespace Generation
{
    public class FixedGeneration : IGeneration
    {
        public FixedGeneration() { }

        public void Fill(IDataContext context)
        {
            User tempUser0 = new User("Tadeusz Chrostowski");
            User tempUser1 = new User("Janusz Domaniewski");
            User tempUser2 = new User("Andrzej Dunajewski");
            User tempUser3 = new User("Jan Haber");
            context.GetUsers().Add(tempUser0);
            context.GetUsers().Add(tempUser1);
            context.GetUsers().Add(tempUser2);
            context.GetUsers().Add(tempUser3);

            Catalog tempCatalog0 = new Catalog("Les Miserables", "Victor Hugo");
            Catalog tempCatalog1 = new Catalog("The Emperor", "Ryszard Kapuscinski");
            Catalog tempCatalog2 = new Catalog("Foundation", "Isaac Asimov");
            Catalog tempCatalog3 = new Catalog("The Call of Cthulhu", "Howard Philips Lovecraft");
            context.GetCatalogs().Add(tempCatalog0);
            context.GetCatalogs().Add(tempCatalog1);
            context.GetCatalogs().Add(tempCatalog2);
            context.GetCatalogs().Add(tempCatalog3);

            State tempState0 = new State(tempCatalog0, 11);
            State tempState1 = new State(tempCatalog1, 22);
            State tempState2 = new State(tempCatalog2, 33);
            State tempState3 = new State(tempCatalog3, 44);
            State tempState4 = new State(tempCatalog0, 55);
            context.GetStates().Add(tempState0);
            context.GetStates().Add(tempState1);
            context.GetStates().Add(tempState2);
            context.GetStates().Add(tempState3);
            context.GetStates().Add(tempState4);

            AbstractEvent tempEvent0 = new BorrowEvent(tempState0, tempUser0, DateTime.Now);
            AbstractEvent tempEvent1 = new BorrowEvent(tempState1, tempUser1, DateTime.Now);
            AbstractEvent tempEvent2 = new BorrowEvent(tempState2, tempUser0, new DateTime(2020, 10, 11, 12, 0, 0));
            AbstractEvent tempEvent3 = new BorrowEvent(tempState3, tempUser1, new DateTime(2020, 10, 11, 12, 0, 0));
            AbstractEvent tempEvent4 = new ReturnEvent(tempState0, tempUser0, DateTime.Now);
            context.GetEvents().Add(tempEvent0);
            context.GetEvents().Add(tempEvent1);
            context.GetEvents().Add(tempEvent2);
            context.GetEvents().Add(tempEvent3);
            context.GetEvents().Add(tempEvent4);
        }
    }
}
