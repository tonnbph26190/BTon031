using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.ProducerViewModel
{
    public class UpdateProducer
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        [Required]
        public int Status { get; set; }
    }
}
