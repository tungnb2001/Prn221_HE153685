using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class PurchaseOrder
    {
        public int OrderId { get; set; }
        public int? SupplierId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
