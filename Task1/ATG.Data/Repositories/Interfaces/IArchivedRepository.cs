using ATG.Domain.Models;

namespace ATG.Data.Repositories.Interfaces
{
    public interface IArchivedRepository
    {
        Lot GetLot(int id);
    }
}
