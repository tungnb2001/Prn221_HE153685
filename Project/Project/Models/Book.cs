using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Book
    {
        public Book()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
        }

        public int BookId { get; set; }
        public int SupplierId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
