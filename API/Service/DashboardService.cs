﻿using API.IService;
using API.ServiceResult;
using API.ViewModel.LatopDetailViewModel;
using API.ViewModel.MonitorViewModel;
using API.ViewModel.OrderDetail;
using API.ViewModel.PcViewModel;

namespace API.Service
{
    public class DashboardService : IDashboardService
    {
        ILapTopDetailService _LaptopDetailService;
        IMonitorDetailService _MonitorDetailService;
        IPcDetailService _PcDetailService;
        IOrderDetailLaptopDetailService _OrderDetailLaptopDetailService;
        IOrderMonitorDetail _OrderMonitorDetail;
        IOrderDetailService _OrderDetailService;
        public DashboardService(ILapTopDetailService laptopDetailService, IMonitorDetailService monitorDetailService, IPcDetailService pcDetailService, IOrderDetailLaptopDetailService OrderDetailLaptopDetailService, IOrderMonitorDetail orderMonitorDetail, IOrderDetailService orderDetailService)
        {
            _LaptopDetailService = laptopDetailService;
            _MonitorDetailService = monitorDetailService;
            _PcDetailService = pcDetailService;
            _OrderDetailLaptopDetailService = OrderDetailLaptopDetailService;
            _OrderMonitorDetail = orderMonitorDetail;
            _OrderDetailService = orderDetailService;
        }
        public async Task<RevenueSummary<LaptopDetailDto>> GetEstimatedRevenueAndAvailabilityForLaptop()
        {
            var laptopDetailData = await _LaptopDetailService.GetAllLaptopDetail();

            var totalPrice = laptopDetailData.Sum(x => x.Price);
            var estimatedRevenue = laptopDetailData.Sum(x => x.Price - x.COGS);
            var availableQuantity = laptopDetailData.Count(x => x.Quatity > 0);
            var notAvailableQuantity = laptopDetailData.Count(x => x.Quatity == 0);
            var lowQuantityProducts = laptopDetailData.Count(x => x.Quatity <= 2 && x.Quatity > 0);

            var revenueSummary = new RevenueSummary<LaptopDetailDto>
            {
                EstimatedRevenue = estimatedRevenue,
                AvailableQuantity = availableQuantity,
                LowQuantityProducts = lowQuantityProducts,
                TotalPrice = totalPrice,
                NotAvailableQuantity = notAvailableQuantity,
            };

            return revenueSummary;
        }

        /// <summary>
        /// Phương thức lấy tổng số tiền hàng, dự kiến thu được, số mặt hàng còn,số hàng còn ít, số hàng hết
        /// </summary>
        /// <returns></returns>
        public async Task<RevenueSummary<MonitorDetailDto>> GetEstimatedRevenueAndAvailabilityForMonitor()
        {
            var monitorDetailData = await _MonitorDetailService.GetAll();

            var totalPrice = monitorDetailData.Sum(x => x.Price);
            var estimatedRevenue = monitorDetailData.Sum(x => x.Price - x.COGS);
            var availableQuantity = monitorDetailData.Count(x => x.Quatity > 0);
            var notAvailableQuantity = monitorDetailData.Count(x => x.Quatity == 0);
            var lowQuantityProducts = monitorDetailData.Count(x => x.Quatity <= 2 && x.Quatity > 0);

            var revenueSummary = new RevenueSummary<MonitorDetailDto>
            {
                EstimatedRevenue = estimatedRevenue,
                AvailableQuantity = availableQuantity,
                LowQuantityProducts = lowQuantityProducts,
                TotalPrice = totalPrice,
                NotAvailableQuantity= notAvailableQuantity,
            };

            return revenueSummary;
        }

        public async Task<RevenueSummary<PcDto>> GetEstimatedRevenueAndAvailabilityForPc()
        {
            var PcDetailData = await _PcDetailService.GetAll();

            var totalPrice = PcDetailData.Sum(x => x.Price);
            var estimatedRevenue = PcDetailData.Sum(x => x.Price - x.COGS); 
            var totalQuantity = PcDetailData.Sum(x => x.Quatity);
            var averageProfitPerProduct = estimatedRevenue / totalQuantity;
            var availableQuantity = PcDetailData.Count(x => x.Quatity > 0);
            var notAvailableQuantity = PcDetailData.Count(x => x.Quatity == 0);
            var lowQuantityProducts = PcDetailData.Count(x => x.Quatity <= 2 && x.Quatity > 0);

            var revenueSummary = new RevenueSummary<PcDto>
            {
                EstimatedRevenue = estimatedRevenue,
                AvailableQuantity = availableQuantity,
                LowQuantityProducts = lowQuantityProducts,
                TotalPrice = totalPrice,
                NotAvailableQuantity = notAvailableQuantity,
                AverageProfitPerProduct = Math.Round(averageProfitPerProduct, 2),
            };

            return revenueSummary;
        }

        /// <summary>
        /// Lấy tổng số hóa đơn bán được và tổng tiền hóa đơn bán được  
        /// </summary>
        /// <returns></returns>
        public async Task<SaleResults> GetTotalSalesForlapTop()
        {
            // Lấy danh sách tất cả chi tiết đơn hàng
            IEnumerable<OrderDetailDto> orderDetails = await _OrderDetailLaptopDetailService.GetAll();

            // Lọc ra các mục có Status = 1 (đã bán)    
            IEnumerable<OrderDetailDto> soldOrderDetails = orderDetails.Where(o => o.Status == 1);

            // Đếm số hóa đơn theo OrderID
            var orderCounts = soldOrderDetails.GroupBy(o => o.OrderID)
                                              .Select(g => new { OrderID = g.Key, OrderCount = g.Count() })
                                              .ToList();

            // Tính tổng tiền hóa đơn đã bán được
            decimal totalSales = soldOrderDetails.Sum(o => o.Price);

            return new SaleResults
            {
                TotalOrder = orderCounts.Count(),
                TotalSale = totalSales,
            };
           
        }

        public async Task<SaleResults> GetTotalSalesForMonitor()
        {
            // Lấy danh sách tất cả chi tiết đơn hàng
            IEnumerable<OrderDetailDto> orderDetails = await _OrderMonitorDetail.GetAll();

            // Lọc ra các mục có Status = 1 (đã bán)
            IEnumerable<OrderDetailDto> soldOrderDetails = orderDetails.Where(o => o.Status == 1);

            // Đếm số hóa đơn theo OrderID
            var orderCounts = soldOrderDetails.GroupBy(o => o.OrderID)
                                              .Select(g => new { OrderID = g.Key, OrderCount = g.Count() })
                                              .ToList();

            // Tính tổng tiền hóa đơn đã bán được
            decimal totalSales = soldOrderDetails.Sum(o => o.Price);

            return new SaleResults
            {
                TotalOrder = orderCounts.Count(),
                TotalSale = totalSales,
            };
        }

        public async Task<SaleResults> GetTotalSalesForPc()
        {
            // Lấy danh sách tất cả chi tiết đơn hàng
            IEnumerable<OrderDetailDto> orderDetails = await _OrderDetailService.GetAll();

            // Lọc ra các mục có Status = 1 (đã bán)
            IEnumerable<OrderDetailDto> soldOrderDetails = orderDetails.Where(o => o.Status == 1);

            // Đếm số hóa đơn theo OrderID
            var orderCounts = soldOrderDetails.GroupBy(o => o.OrderID)
                                              .Select(g => new { OrderID = g.Key, OrderCount = g.Count() })
                                              .ToList();

            // Tính tổng tiền hóa đơn đã bán được
            decimal totalSales = soldOrderDetails.Sum(o => o.Price);

            return new SaleResults
            {
                TotalOrder = orderCounts.Count(),
                TotalSale = totalSales,
            };
        }

        /// <summary>
        /// Lấy sản phẩm bán chạy
        /// </summary>
        /// <returns></returns>
        public async Task<ProductDto> GetBestSellingProductForPc()
        {
            // Lấy danh sách tất cả chi tiết đơn hàng
            IEnumerable<OrderDetailDto> orderDetails = await _OrderDetailService.GetAll();

            // Nhóm các mục theo ProductID và tính tổng số lượng đã bán
            var productSales = orderDetails.GroupBy(o => o.ProductID)
                                           .Select(g => new { ProductID = g.Key, TotalQuantitySold = g.Sum(o => o.Quatity) })
                                           .ToList();

            // Lấy sản phẩm bán chạy nhất (sắp xếp theo tổng số lượng bán giảm dần và lấy mục đầu tiên)
            var bestSellingProduct = productSales.OrderByDescending(p => p.TotalQuantitySold)
                                                .FirstOrDefault();

            if (bestSellingProduct == null)
            {
                return null;
            }

            // Lấy thông tin chi tiết của sản phẩm bán chạy nhất
            var product = _PcDetailService.GetAll().Result.FirstOrDefault(p => p.ID == bestSellingProduct.ProductID);

            if (product == null)
            {
                return null;
            }

            // Tạo đối tượng ProductDto để trả về
            var bestSellingProductDto = new ProductDto
            {
                ID = product.ID,
                Name = product.Name,
                TotalQuantitySold = bestSellingProduct.TotalQuantitySold
            };

            return bestSellingProductDto;
        }

        public async Task<ProductDto> GetBestSellingProductForMonitor()
        {
            // Lấy danh sách tất cả chi tiết đơn hàng
            IEnumerable<OrderDetailDto> orderDetails = await _OrderMonitorDetail.GetAll();

            // Nhóm các mục theo ProductID và tính tổng số lượng đã bán
            var productSales = orderDetails.GroupBy(o => o.ProductID)
                                           .Select(g => new { ProductID = g.Key, TotalQuantitySold = g.Sum(o => o.Quatity) })
                                           .ToList();

            // Lấy sản phẩm bán chạy nhất (sắp xếp theo tổng số lượng bán giảm dần và lấy mục đầu tiên)
            var bestSellingProduct = productSales.OrderByDescending(p => p.TotalQuantitySold)
                                                .FirstOrDefault();

            if (bestSellingProduct == null)
            {
                return null;
            }

            // Lấy thông tin chi tiết của sản phẩm bán chạy nhất
            var product = _MonitorDetailService.GetAll().Result.FirstOrDefault(p => p.ID == bestSellingProduct.ProductID);

            if (product == null)
            {
                return null;
            }

            // Tạo đối tượng ProductDto để trả về
            var bestSellingProductDto = new ProductDto
            {
                ID = product.ID,
                Name = product.Name,
                TotalQuantitySold = bestSellingProduct.TotalQuantitySold
            };

            return bestSellingProductDto;
        }

        public async Task<ProductDto> GetBestSellingProductForLaptop()
        {
            // Lấy danh sách tất cả chi tiết đơn hàng
            IEnumerable<OrderDetailDto> orderDetails = await _OrderDetailLaptopDetailService.GetAll();

            // Nhóm các mục theo ProductID và tính tổng số lượng đã bán
            var productSales = orderDetails.GroupBy(o => o.ProductID)
                                           .Select(g => new { ProductID = g.Key, TotalQuantitySold = g.Sum(o => o.Quatity) })
                                           .ToList();

            // Lấy sản phẩm bán chạy nhất (sắp xếp theo tổng số lượng bán giảm dần và lấy mục đầu tiên)
            var bestSellingProduct = productSales.OrderByDescending(p => p.TotalQuantitySold)
                                                .FirstOrDefault();

            if (bestSellingProduct == null)
            {
                return null;
            }

            // Lấy thông tin chi tiết của sản phẩm bán chạy nhất
            var product = _LaptopDetailService.GetAllLaptopDetail().Result.FirstOrDefault(p => p.ID == bestSellingProduct.ProductID);

            if (product == null)
            {
                return null;
            }

            // Tạo đối tượng ProductDto để trả về
            var bestSellingProductDto = new ProductDto
            {
                ID = product.ID,
                Name = product.Name,
                TotalQuantitySold = bestSellingProduct.TotalQuantitySold
            };

            return bestSellingProductDto;
        }

        /// <summary>
        /// select ra những ngày mà có ít và nhiều hóa đơn được tạo
        /// </summary>
        /// <returns></returns>
        public async Task<OrderDateRangeDto> GetMostAndLeastOrdersDateRangeDtoForLaptop()
        {
            // Lấy danh sách các OrderDetailDtos liên quan đến Laptop
            var laptopOrderDetailDtos = await _OrderDetailLaptopDetailService.GetAll();

            // Nhóm các OrderDetailDtos theo ngày tạo
            var groupedByDate = laptopOrderDetailDtos.GroupBy(o => o.CreateDate.Date);

            var mostOrdersDateRange = groupedByDate.OrderByDescending(g => g.Count()).FirstOrDefault();
            var leastOrdersDateRange = groupedByDate.OrderBy(g => g.Count()).FirstOrDefault();

            // Lấy số hóa đơn bán được tương ứng với khoảng thời gian có số lượng hóa đơn nhiều nhất
            int mostOrdersCount = mostOrdersDateRange?.Count() ?? 0;
            // Lấy số hóa đơn bán được tương ứng với khoảng thời gian có số lượng hóa đơn ít nhất
            int leastOrdersCount = leastOrdersDateRange?.Count() ?? 0;

            return new OrderDateRangeDto
            {
                MostOrdersDate = mostOrdersDateRange?.Key ?? DateTime.MinValue,               
                LeastOrdersDate = leastOrdersDateRange?.Key ?? DateTime.MinValue,
                MostOrdersCount = mostOrdersCount,
                LeastOrdersCount = leastOrdersCount
            };
        }

        /// <summary>
        /// Lấy ra những ngày mà không có hóa đơn nào tạo theo khoảng thời gian
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DateTime>> GetEmptyDateRanges(DateTime startDate, DateTime endDate)
        {
            var laptopOrderDetailDtos = await _OrderDetailLaptopDetailService.GetAll();

            var orderedDates = laptopOrderDetailDtos
                .Select(dto => dto.CreateDate.Date)
                .Distinct()
                .OrderBy(date => date)
                .ToList();

            var emptyDateRanges = Enumerable.Range(0, (endDate - startDate).Days + 1)
                .Select(offset => startDate.AddDays(offset))
                .Except(orderedDates)
                .ToList();

            return emptyDateRanges;
        }

        /// <summary>
        /// Tính toán số tiền thu được theo khoảng thời gian
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<SaleResults> CalculateRevenueAndTotalOrdersByTimeRange(DateTime startDate, DateTime endDate)
        {
            var orderDetails = await _OrderDetailLaptopDetailService.GetAll();

            decimal totalRevenue = orderDetails
                .Where(o => o.CreateDate >= startDate && o.CreateDate <= endDate)
                .Sum(o => o.Price);

            int totalOrders = orderDetails
                .Count(o => o.CreateDate >= startDate && o.CreateDate <= endDate);

            return new SaleResults() {TotalOrder=totalOrders, TotalSale=totalRevenue };
        }
    }
}



