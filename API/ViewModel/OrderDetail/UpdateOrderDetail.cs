using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.OrderDetail
{
    public class UpdateOrderDetail:IOrderDetail
    {
        [RegularExpression(@"^(?!0)\d+$")]
        public int Quatity { get; set; }
        [MaxLength(50)]
        public string OrderID { get; set; }
        [MaxLength(50)]
        public string PcDetailID { get; set; }
        public int Status { get; set; }

    }
}
