using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.ViewModel
{
    public class UpdateViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        [MaxLength(50)]
        public string? Values { get; set; }
    }
}
