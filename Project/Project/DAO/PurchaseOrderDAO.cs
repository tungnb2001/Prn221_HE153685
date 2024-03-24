using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    public class PurchaseOrderDAO
    {
        public ObservableCollection<PurchaseOrder> loadAllPurchaseOrder()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            var list = new ObservableCollection<PurchaseOrder>(context.PurchaseOrders.ToList());
            return list;
        }

        public decimal GetTotalPurchaseOrderAmount()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            loadAllPurchaseOrder();
            return context.PurchaseOrders.Sum(order => order.TotalAmount ?? 0);
        }

        public ObservableCollection<double> GetMonthlyPurchaseOrderAmounts(DateTime startDate, DateTime endDate)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            ObservableCollection<double> amounts = new ObservableCollection<double>();
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                decimal amountForMonth = context.PurchaseOrders
                    .Where(order => order.OrderDate.HasValue && order.OrderDate.Value.Year == currentDate.Year && order.OrderDate.Value.Month == currentDate.Month)
                    .Sum(order => order.TotalAmount ?? 0);

                amounts.Add((double)amountForMonth);
                currentDate = currentDate.AddMonths(1);
            }
            loadAllPurchaseOrder();
            return amounts;
        }
    }
}
