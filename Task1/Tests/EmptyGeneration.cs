using Data;

namespace Tests
{
    public class EmptyGeneration : IGeneration
    {

        public EmptyGeneration() { }

        public static IDataContext Fill(IDataContext context)
        {
            return context;
        }
    }
}
