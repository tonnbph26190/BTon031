using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.Screen
{
    public class CreatScreen
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Size { get; set; }
        [MaxLength(50)]
        public string Rate { get; set; }
    }
}
