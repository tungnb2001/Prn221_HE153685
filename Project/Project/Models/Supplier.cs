using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Books = new HashSet<Book>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
