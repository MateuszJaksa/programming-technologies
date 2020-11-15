using Data;

namespace Generation
{
    public interface IGeneration
    {
        void Fill(DataContext context);
    }
}
