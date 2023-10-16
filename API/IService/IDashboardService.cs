using API.ServiceResult;
using API.ViewModel.LatopDetailViewModel;
using API.ViewModel.MonitorViewModel;
using API.ViewModel.PcViewModel;

namespace API.IService
{
    public interface IDashboardService
    {
        Task<RevenueSummary<LaptopDetailDto>> GetEstimatedRevenueAndAvailabilityForLaptop();
        Task<RevenueSummary<MonitorDetailDto>> GetEstimatedRevenueAndAvailabilityForMonitor();
        Task<RevenueSummary<PcDto>> GetEstimatedRevenueAndAvailabilityForPc();
        Task<SaleResults> GetTotalSalesForlapTop();
        Task<SaleResults> GetTotalSalesForPc();
        Task<SaleResults> GetTotalSalesForMonitor();
        Task<ProductDto> GetBestSellingProductForPc();
        Task<ProductDto> GetBestSellingProductForMonitor();
        Task<ProductDto> GetBestSellingProductForLaptop();
        Task<OrderDateRangeDto> GetMostAndLeastOrdersDateRangeDtoForLaptop();
        Task<IEnumerable<DateTime>> GetEmptyDateRanges(DateTime startDate, DateTime endDate);
        Task<SaleResults> CalculateRevenueAndTotalOrdersByTimeRange(DateTime startDate, DateTime endDate);
    }
}
