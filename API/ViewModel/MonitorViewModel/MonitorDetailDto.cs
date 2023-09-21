using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.MonitorViewModel
{
    public class MonitorDetailDto
    {
        [Required]
        [StringLength(30)]
        public string ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Seri { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal COGS { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Price { get; set; }
        [RegularExpression(@"^-?\d+$")]
        [Range(0, 5, ErrorMessage = "Trạng thái phải từ 0 đến 5")]
        public int Status { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Quatity { get; set; }
        [Required]
        [StringLength(20)]
        public string Rate { get; set; }
        [Required]
        [RegularExpression(@"^-?\d+$")]
        public int Inch { get; set; }
        [Required]
        [RegularExpression(@"^-?\d+$")]
        public int Brightness { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public int ResponseTime { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Speaker { get; set; }
        [Required]
        [StringLength(50)]
        public string Display { get; set; }
        [Required]
        [StringLength(50)]
        public string ResolutionValue { get; set; }
        [Required]
        [StringLength(50)]
        public string PanelName { get; set; }
        [Required]
        [StringLength(50)]
        public string MonitorName { get; set; }
        public string ProducreName { get; set; }
        public string CatgoryName { get; set; }
        
        [StringLength(100)]
        public string Name { get; set; }

    }
}
