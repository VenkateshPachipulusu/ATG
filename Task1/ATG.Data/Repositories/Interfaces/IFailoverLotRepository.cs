using ATG.Domain.Models;
using System.Collections.Generic;

namespace ATG.Data.Repositories.Interfaces
{
    public interface IFailoverLotRepository
    {
        Lot GetLot(int id);

        List<FailoverLots> GetFailOverLotEntries();
    }
}
