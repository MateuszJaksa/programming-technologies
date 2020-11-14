using Data;

namespace Tests
{
    public class EmptyGeneration : IGeneration
    {

        public EmptyGeneration() { }

        public void Fill(DataContext context)
        { }
    }
}
