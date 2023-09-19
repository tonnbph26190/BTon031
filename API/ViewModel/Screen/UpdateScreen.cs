using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.Screen
{
    public class UpdateScreen
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        [MaxLength(50)]
        public string Size { get; set; }
        [MaxLength(50)]
        public string Rate { get; set; }
    }
}
