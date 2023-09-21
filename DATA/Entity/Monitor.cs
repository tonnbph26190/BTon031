using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class Monitor
    {
        [Key]
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
        public string CatId { get; set; }
        [Required]
        [StringLength(30)]
        public string ProducerId { get; set; }
        public Producer? producer { get; set; }
        public Category? Category { get; set; }
        public ICollection<MonitorDetail>? MonitorDetails { get; set; }
    }
}
