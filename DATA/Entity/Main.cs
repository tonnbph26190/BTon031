﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class Main
    {
        [Required]
        [StringLength(30)]
        public string ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        [MaxLength(50)]
        public string? Parameter { get; set; }
        public ICollection<Laptop_Detail> Laptop_Detail { get; set; }
        public ICollection<PcDetail> PcDetails { get; set; }

    }
}
