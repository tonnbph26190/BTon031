﻿using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.RamViewModel
{
    public class UpdateRam
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        [MaxLength(50)]
        public string? Parameter { get; set; }
    }
}
