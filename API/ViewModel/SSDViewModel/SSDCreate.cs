using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.SSDViewModel
{
    public class SSDCreate
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Parameter { get; set; }
    }
}
