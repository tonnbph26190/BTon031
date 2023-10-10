using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class OrderDetail
    {
        [Key]
        [MaxLength(50)]
        public string ID { get; set; }
        public int Quatity { get; set; }
        [MaxLength(50)]
        public string OrderID { get; set; }
        [MaxLength(50)]
        public string PcDetailID { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public PcDetail PcDetail { get; set; }
        public Order Order { get; set; }

    }
}
