using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            InventoryTransactions = new HashSet<InventoryTransaction>();
        }

        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
