using Data;

namespace Tests
{
    class EmptyGeneration : IGeneration
    {

        EmptyGeneration() { }

        public void Fill(DataContext context)
        { }
    }
}
