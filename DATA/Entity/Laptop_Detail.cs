using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class Laptop_Detail
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
        [StringLength(30)]
        public string IdSSD { get; set; }
        [Required]
        [StringLength(30)]
        public string IdRam { get; set; }
        [Required]
        [StringLength(30)]
        public string IdVga { get; set; }
        [Required]
        [StringLength(30)]
        public string IdBattery { get; set; }
        [Required]
        [StringLength(30)]
        public string IdMain { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Weight { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Hight { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal leght { get; set; }
        [Required]
        [StringLength(30)]
        public string IdCam { get; set; }
        [Required]
        [StringLength(30)]
        public string IdScren { get; set; }
        [Required]
        [StringLength(30)]
        public string IdLap { get; set; }
        public SSD? SSD { get; set; }
        public Ram? Ram { get; set; }
        public VGA? VGA { get; set; }
        public Battery? Battery { get; set; }
        public Main? Main { get; set; }
        public Webcam? Webcam { get; set; }
        public Screen? Screen { get; set; }

        public Laptop? Laptop { get; set; }
    }
}
