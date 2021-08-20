using ATG.Data.Repositories.Interfaces;
using ATG.Domain.Models;
using ATG.Services.Services.Interfaces;
using System;
using System.Linq;

namespace ATG.Services.Services
{
    public class LotService : ILotService
    {
        private readonly IFailoverLotRepository _failoverLotRepository;
        private readonly IArchivedRepository _archivedRepository;
        private readonly ILotRepository _lotRepository;

        public LotService(IFailoverLotRepository failoverLotRepository, IArchivedRepository archivedRepository, ILotRepository lotRepository)
        {
            _failoverLotRepository = failoverLotRepository;
            _archivedRepository = archivedRepository;
            _lotRepository = lotRepository;
        }

        public Lot GetLot(int id, int maxFailedRequests, bool isLotArchived, bool isFailoverModeEnabled)
        {
            Lot lot = null;

            var failoverLots = _failoverLotRepository.GetFailOverLotEntries();
            var failedRequests = failoverLots.Count(failoverLotsEntry => failoverLotsEntry.DateTime < DateTime.Now.AddMinutes(10));

            if (failedRequests > maxFailedRequests && isFailoverModeEnabled)
            {
                lot = _failoverLotRepository.GetLot(id);
            }

            if (lot is { IsArchived: true } && isLotArchived)
            {
                return _archivedRepository.GetLot(id);
            }

            return _lotRepository.LoadCustomer();
        }
    }
}
