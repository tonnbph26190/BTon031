﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.ViewModel.PcViewModel
{
    public class CreatePcDetail:IPcDetailViewModel
    {

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
        public string SSDId { get; set; }
        [Required]
        [StringLength(30)]
        public string RamID { get; set; }
        [Required]
        [StringLength(30)]
        public string VgaID { get; set; }
        [Required]
        [StringLength(30)]
        public string MainID { get; set; }
        [AllowNull]
        [StringLength(30)]
        public string CustomID { get; set; }
        [Required]
        [StringLength(30)]
        public string CoolingID { get; set; }
        [Required]
        [StringLength(30)]
        public string CaseID { get; set; }
        [Required]
        [StringLength(30)]
        public string PcID { get; set; }
        [Required]
        [StringLength(30)]
        public string PowerID { get; set; }
    }
}