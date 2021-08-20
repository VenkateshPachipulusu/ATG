using ATG.Data.Repositories.Base;
using ATG.Data.Repositories.Interfaces;
using ATG.Domain.Models;
using System.Collections.Generic;

namespace ATG.Data.Repositories
{
    public class FailoverLotRepository : RepositoryBase, IFailoverLotRepository
    {
        public Lot GetLot(int id)
        {
            return new Lot();
        }
        public List<FailoverLots> GetFailOverLotEntries()
        {
            return new List<FailoverLots>();
        }
    }
}
