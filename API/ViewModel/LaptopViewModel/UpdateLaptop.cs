using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.LaptopViewModel
{
    public class UpdateLaptop
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        [Required]
        [StringLength(30)]
        public string IdCat { get; set; }
        [Required]
        [StringLength(30)]
        public string IdProducer { get; set; }
    }
}
