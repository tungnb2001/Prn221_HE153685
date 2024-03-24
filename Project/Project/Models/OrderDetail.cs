using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Total { get; set; }
       
    }
}
