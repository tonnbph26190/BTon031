using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.OrderDetail
{
    public class OrderDetailDto
    {
       
        public string ID { get; set; }
        public int Quatity { get; set; }
        public string OrderID { get; set; }
        public string ProductName { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
