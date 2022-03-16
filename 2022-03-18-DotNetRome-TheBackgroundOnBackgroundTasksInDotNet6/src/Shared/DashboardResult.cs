using System;

namespace Shared
{
    public class DashboardResult
    {
        public decimal NumberOfSales { get; set; }
        public decimal AverageSale { get; set; }
        public decimal TotalSales => NumberOfSales * AverageSale;
        public DateTime LastUpdated { get; set; }
    }
}