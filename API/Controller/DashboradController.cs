using API.IService;
using API.Service;
using API.ServiceResult;
using API.ViewModel.LatopDetailViewModel;
using API.ViewModel.MonitorViewModel;
using API.ViewModel.PcViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboradController : ControllerBase
    {
        IDashboardService _DashboardService;
        public DashboradController(IDashboardService DashboardService)
        {
            _DashboardService= DashboardService;
        }
        [HttpGet("revenue-monitor")]
        public async Task<ActionResult<RevenueSummary<MonitorDetailDto>>> GetEstimatedRevenueAndAvailabilityForMonitor()
        {
            var revenueSummary = await _DashboardService.GetEstimatedRevenueAndAvailabilityForMonitor();
            return Ok(revenueSummary);
        }

        [HttpGet("sales-monitor")]
        public async Task<ActionResult<SaleResults>> GetTotalSalesForMonitor()
        {
            var saleResults = await _DashboardService.GetTotalSalesForMonitor();
            return Ok(saleResults);
        }

        [HttpGet("best-selling-monitor")]
        public async Task<ActionResult<ProductDto>> GetBestSellingProductForMonitor()
        {
            var bestSellingProduct = await _DashboardService.GetBestSellingProductForMonitor();
            if (bestSellingProduct == null)
            {
                return NotFound();
            }
            return Ok(bestSellingProduct);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("revenue-pc")]
        public async Task<ActionResult<RevenueSummary<PcDto>>> GetEstimatedRevenueAndAvailabilityForPc()
        {
            var revenueSummary = await _DashboardService.GetEstimatedRevenueAndAvailabilityForPc();
            return Ok(revenueSummary);
        }

        [HttpGet("sales-pc")]
        public async Task<ActionResult<SaleResults>> GetTotalSalesForPc()
        {
            var saleResults = await _DashboardService.GetTotalSalesForPc();
            return Ok(saleResults);
        }

        [HttpGet("best-selling-pc")]
        public async Task<ActionResult<ProductDto>> GetBestSellingProductForPc()
        {
            var bestSellingProduct = await _DashboardService.GetBestSellingProductForPc();
            if (bestSellingProduct == null)
            {
                return NotFound();
            }
            return Ok(bestSellingProduct);
        }

        [HttpGet("revenue-laptop")]
        public async Task<ActionResult<RevenueSummary<LaptopDetailDto>>> GetEstimatedRevenueAndAvailabilityForLaptop()
        {
            var revenueSummary = await _DashboardService.GetEstimatedRevenueAndAvailabilityForLaptop();
            return Ok(revenueSummary);
        }

        [HttpGet("sales-laptop")]
        public async Task<ActionResult<SaleResults>> GetTotalSalesForLaptop()
        {
            var saleResults = await _DashboardService.GetTotalSalesForlapTop();
            return Ok(saleResults);
        }

        [HttpGet("best-selling-laptop")]
        public async Task<ActionResult<ProductDto>> GetBestSellingProductForLaptop()
        {
            var bestSellingProduct = await _DashboardService.GetBestSellingProductForLaptop();
            if (bestSellingProduct == null)
            {
                return NotFound();
            }
            return Ok(bestSellingProduct);
        }
    }
}
