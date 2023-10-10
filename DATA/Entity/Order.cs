using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class Order
    {
        [Key]
        [MaxLength(50)]
        public string ID { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails{ get; set; }
    }
}
