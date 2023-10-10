using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class PcDetail
    {
        [Key]
        [Required]
        [StringLength(30)]
        public string ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Seri { get; set; }
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
        public SSD? SSD { get; set; }
        public Ram? Ram { get; set; }
        public VGA? VGA { get; set; }
        public Main? Main { get; set; }
        public PC? PC { get; set; }
        public Power? Power { get; set; }
        public Cooling? cooling { get; set; }
        public Custom? Custom { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
