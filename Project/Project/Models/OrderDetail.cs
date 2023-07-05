using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int EmployeeId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Book Book { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
