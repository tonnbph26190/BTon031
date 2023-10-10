using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class Producer
    {
        [Required]
        [Key]
        [StringLength(30)]
        public string ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }
        public ICollection<Laptop>? Laptop { get; set; }
        public ICollection<PC>? PCs { get; set; }
        public ICollection<Monitor>? Monitors { get; set; }
    }
}
