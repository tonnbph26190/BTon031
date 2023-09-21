using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.CustomViewModel
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Values { get; set; }
    }
}
