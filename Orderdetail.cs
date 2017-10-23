using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErDat
{
    class Orderdetail
    {
        [Column("OrderId")]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        //public List<Orderdetail> Orderdetails { get; set; }
    }
}
