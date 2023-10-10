using System;
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
        [Key]
        public string ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        [MaxLength(50)]
        public string? Parameter { get; set; }
        public decimal? Price { get; set; }
        public decimal? COGS { get; set; }
        [Required]
        [Range(1, 2)]
        [RegularExpression(@"^\d+$")]
        public int Type { get; set; }
        public int? Quatity { get; set; }
        public ICollection<Laptop_Detail> Laptop_Detail { get; set; }
        public ICollection<PcDetail> PcDetails { get; set; }

    }
}
