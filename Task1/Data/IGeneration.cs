using Data;

namespace Generation
{
    public interface IGeneration
    {
        void Fill(IDataContext context);
    }
}
