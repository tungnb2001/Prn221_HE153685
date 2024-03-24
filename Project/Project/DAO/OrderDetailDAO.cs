using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAO
{
    public class OrderDetailDAO
    {

        public ObservableCollection<OrderDetail> loadAllOrderDetail()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            var list = new ObservableCollection<OrderDetail>(context.OrderDetails.ToList());
            return list;
        }
        public OrderDetail getOrderDetailById(int orderdetailId)
        {
                PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
                OrderDetail orderDetail = context.OrderDetails.FirstOrDefault(od => od.OrderDetailId == orderdetailId);
                return orderDetail;
           
        }
        public decimal GetTotalOrderDetailAmount()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            loadAllOrderDetail();
            return context.OrderDetails.Sum(detail => detail.Total);
        }

        public ObservableCollection<double> GetMonthlyOrderDetailAmounts(DateTime startDate, DateTime endDate)
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            ObservableCollection<double> amounts = new ObservableCollection<double>();
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                decimal amountForMonth = context.OrderDetails
                    .Where(detail => detail.DateCreated.Year == currentDate.Year && detail.DateCreated.Month == currentDate.Month)
                    .Sum(detail => detail.Total);

                amounts.Add((double)amountForMonth);
                currentDate = currentDate.AddMonths(1);
            }
            loadAllOrderDetail();
            return amounts;
        }
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context())
                {
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public ObservableCollection<OrderDetail> SortOrderDetailsByDate()
        {
            PRN221_Project_HE153685Context context = new PRN221_Project_HE153685Context();
            var sortedList = new ObservableCollection<OrderDetail>(context.OrderDetails.OrderBy(od => od.DateCreated));
            return sortedList;
        }

    }
}
