using ATG.Domain.Models;

namespace ATG.Services.Services.Interfaces
{
    public interface ILotService
    {
        Lot GetLot(int id, int maxFailedRequests, bool isLotArchived, bool isFailoverModeEnabled);
    }
}
