using API.ViewModel.LatopDetailViewModel;

namespace API.ServiceResult
{
    public class ServiceResults<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class RevenueSummary<T>
    {
        public decimal EstimatedRevenue { get; set; }
        public int AvailableQuantity { get; set; }
        public int NotAvailableQuantity { get; set; }
        public int LowQuantityProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class SaleResults 
    {
        public Decimal TotalSale { get; set; }
        public int TotalOrder { get; set; }
    }
    public class ProductDto 
    {
        public string ID { get; set; }
        public string Name   { get; set; }
        public int TotalQuantitySold { get; set; }
        
    }
}
