using ATG.Domain.Models;
using System;
using System.Collections.Generic;

namespace ATG.Tests.TestData
{
    public static class MockUpData
    {
        public static List<FailoverLots> FailoverLots(int maxFailedRequests, bool isLessThanMaxLimitReach)
        {
            List<FailoverLots> failoverLots = new List<FailoverLots>();
            for (int i = 0; i <= (isLessThanMaxLimitReach ? maxFailedRequests - 2 : maxFailedRequests); i++)
            {
                failoverLots.Add(new FailoverLots() { DateTime = DateTime.Now.AddDays(-i) });
            }

            return failoverLots;
        }

        public static Lot LoadCustomer()
        {
            Lot lot = new Lot()
            {
                Id = 1,
                Description = "Test",
                IsArchived = true,
                Name = "Test01",
                Price = 10m
            };
            return lot;
        }
    }
}
