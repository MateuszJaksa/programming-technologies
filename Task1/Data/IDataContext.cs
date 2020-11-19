using System.Collections.Generic;

namespace Data
{
    public interface IDataContext
    {
        IList<ICatalog> Catalogs { get; }

        IList<AbstractEvent> Events { get; }

        IList<IState> States { get; }

        IList<IUser> Users { get; }
    }
}
