using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.CustomViewModel
{
    public class UpdateCustomViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        [MaxLength(50)]
        public string Value { get; set; }
        public decimal? Price { get; set; }
        public decimal? COGS { get; set; }
        public int? Quatity { get; set; }
    }
}
