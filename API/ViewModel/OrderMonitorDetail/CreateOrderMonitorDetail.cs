using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.OrderMonitorDetail
{
    public class CreateOrderMonitorDetail
    {
        [RegularExpression(@"^(?!0)\d+$")]
        public int Quatity { get; set; }
        [MaxLength(50)]
        public string OrderID { get; set; }
        [MaxLength(50)]
        public string MonitorDetailID { get; set; }
    }
}
