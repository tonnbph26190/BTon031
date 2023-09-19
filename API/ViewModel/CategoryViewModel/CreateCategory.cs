using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.CategoryViewModel
{
    public class CreateCategory
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
