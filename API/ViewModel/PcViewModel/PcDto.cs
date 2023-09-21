using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.PcViewModel
{
    public class PcDto
    {
        [StringLength(20)]
        public string ID { get; set; }
        [StringLength(30)]
        public string Seri { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal COGS { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Price { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Quatity { get; set; }
        [StringLength(30)]
        public string SSDName { get; set; }
        [StringLength(30)]
        public string RamName { get; set; }
        [StringLength(30)]
        public string VgaName { get; set; }
        [StringLength(30)]
        public string MainName { get; set; }
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        [StringLength(30)]
        public string PowerName { get; set; }
        [StringLength(30)]
        public string PCName { get; set; }
    
        [StringLength(100)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        [Range(0, 5, ErrorMessage = "Trạng thái phải từ 0 đến 5")]
        public int Status { get; set; }
        [StringLength(30)]
        public string RamValue { get; set; }
        [StringLength(30)]
        public string MainValue { get; set; }
        [StringLength(30)]
        public string VGaValue { get; set; }
        [StringLength(30)]
        public string SSDValue { get; set; }
        [StringLength(30)]
        public string CategoryName { get; set; }
        [StringLength(30)]
        public string ProducerName { get; set; }
        [StringLength(30)]
        public string CoolingName { get; set; }
        [StringLength(30)]
        public string PowerValue { get; set; }
        [StringLength(30)]
        public string CaseName { get; set; }


    }
}

