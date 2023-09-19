using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class Laptop
    {
        [Required]
        [StringLength(30)]
        public string ID { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [RegularExpression(@"^-?\d+$")]
        public int Status { get; set; }  
        [Required]
        [StringLength(30)]
        public string IdCat { get; set; }
        [Required]
        [StringLength(30)]
        public string IdProducer { get; set; }
        public  ICollection<Laptop_Detail>? Laptop_Detail { get; set; }
        public Producer? producer  { get; set; }
        public Category? Category { get; set; }
    }
}
