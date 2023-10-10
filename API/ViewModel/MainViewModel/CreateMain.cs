﻿using System.ComponentModel.DataAnnotations;

namespace API.ViewModel.MainViewModel
{
    public class CreateMain
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Parameter { get; set; }
        public decimal? Price { get; set; }
        public decimal? COGS { get; set; }
        [Required]
        [Range(1, 2)]
        [RegularExpression(@"^\d+$")]
        public int Type { get; set; }
        public int? Quatity { get; set; }
    }
}
