using ATG.Data.Repositories.Base;
using ATG.Data.Repositories.Interfaces;
using ATG.Domain.Models;

namespace ATG.Data.Repositories
{
    public class LotRepository : RepositoryBase, ILotRepository
    {
        public Lot LoadCustomer()
        {
            return new Lot();
        }
    }
}
