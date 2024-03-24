using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class OrderDetailWrapper
    {
        public OrderDetailWrapper()
        {
        }

        public OrderDetailWrapper(OrderDetail orderDetail)
        {
            OrderDetail = orderDetail;
        }

        public OrderDetail OrderDetail { get; set; }
        public List<SelectedBookItem> BookList { get; set; }
    }
}
