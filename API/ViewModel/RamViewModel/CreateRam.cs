using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.RamViewModel
{
    public class CreateRam
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Parameter { get; set; }
    }
}
