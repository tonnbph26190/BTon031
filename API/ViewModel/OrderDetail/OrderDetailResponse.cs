using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.OrderDetail
{
    public class OrderDetailResponse
    {
      
        public string ID { get; set; }
        public int Quatity { get; set; }            
        public string OrderID { get; set; }
        public string PcDetailID { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
