using ATG.Data.Repositories.Base;
using ATG.Data.Repositories.Interfaces;
using ATG.Domain.Models;

namespace ATG.Data.Repositories
{
    public class ArchivedRepository : RepositoryBase, IArchivedRepository
    {
        public Lot GetLot(int id)
        {
            return new Lot();
        }
    }
}
