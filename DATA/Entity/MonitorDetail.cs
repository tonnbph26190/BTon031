using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class MonitorDetail
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
        public string ResolutionID { get; set; }
        [Required]
        [StringLength(50)]
        public string PanelID { get; set; }
        [Required]
        [StringLength(50)]
        public string MonitorID { get; set; }

        public Panel Panel { get; set; }
        public Monitor Monitor { get; set; }
        public Resolution Resolution { get; set; }
    }
}
