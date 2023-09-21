using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.LatopDetailViewModel
{
    public class LaptopDetailDto
    {

        [Required]
        [StringLength(20)]
        public string ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Seri { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal COGS { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Price { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Quatity { get; set; }
        [Required]
        [StringLength(30)]
        public string SSDName { get; set; }
        [Required]
        [StringLength(30)]
        public string RamName { get; set; }
        [Required]
        [StringLength(30)]
        public string VgaName { get; set; }
        [Required]
        [StringLength(30)]
        public string BatteryName { get; set; }
        [Required]
        [StringLength(30)]
        public string MainName { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Weight { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Hight { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal leght { get; set; }
        [Required]
        [StringLength(30)]
        public string CamName { get; set; }
        [Required]
        [StringLength(30)]
        public string ScreenName { get; set; }
        [Required]
        [StringLength(30)]
        public string LaptopName { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        [Range(0, 5, ErrorMessage = "Trạng thái phải từ 0 đến 5")]
        public int Status { get; set; }
        public string RamPara { get; set; }
        public string CpuPara { get; set; }
        public string MainPara { get; set; }
        public string PinPara { get; set; }
        public string ScrenPara { get; set; }
        public string CAMPara { get; set; }
        public string VGaPara { get; set; }
        public string SSDPara { get; set; }
        public string ScreenSize { get; set; }
        public string ScreenRate { get; set; }
        public string  CategoryName { get; set; }
        public string  ProducerName { get; set; }


    }
}
