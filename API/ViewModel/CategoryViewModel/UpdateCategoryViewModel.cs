using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.CategoryViewModel
{
    public class UpdateCategoryViewModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
    }
}
