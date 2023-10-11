using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.OrderDetailLaptopDetailViewModel
{
    public class CreateOrdDetailLaptopDetail
    {
        [RegularExpression(@"^(?!0)\d+$")]
        public int Quatity { get; set; }
        [MaxLength(50)]
        public string OrderID { get; set; }
        [MaxLength(50)]
        public string LaptopDetailID { get; set; }
    }
}
