using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class InventoryTransaction
    {
        public int TransactionId { get; set; }
        public int BookId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
