using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.ProducerViewModel
{
    public class CreateProducer
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
