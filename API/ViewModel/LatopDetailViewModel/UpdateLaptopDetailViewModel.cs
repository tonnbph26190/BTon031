﻿using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.LatopDetailViewModel
{
    public class UpdateLaptopDetailViewModel:ILaptopDetailViewModel
    {
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
        public string IdScreen { get; set; }
        [Required]
        [StringLength(30)]
        public string IdLap { get; set; }
       
    }
}
