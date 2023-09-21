using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.ViewModel.LatopDetailViewModel
{
    public interface ILaptopDetailViewModel
    {
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
        [Required]
        [StringLength(30)]
        public string IdCam { get; set; }
        [Required]
        [StringLength(30)]
        public string IdScreen { get; set; }
        [Required]
        [StringLength(30)]
        public string IdLap { get; set; }
        [AllowNull]
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Weight { get; set; }
        [AllowNull]
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal Hight { get; set; }
        [AllowNull]
        [RegularExpression(@"^-?\d+(\.\d+)?$")]
        public decimal leght { get; set; }
    }
}
