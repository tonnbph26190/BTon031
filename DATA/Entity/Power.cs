using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class Power
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
        public string Value { get; set; }
        public decimal? Price { get; set; }
        public decimal? COGS { get; set; }
        public int? Quatity { get; set; }
        public ICollection<PcDetail> PC_Detail { get; set; }
    }
}
