using Project.DAO;
using Project.Models;
using Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project.UserControls
{
    /// <summary>
    /// Interaction logic for OrderDetailManager.xaml
    /// </summary>
    /// 
    
    public partial class OrderDetailManager : UserControl
    {
        private readonly OrderDetailDAO orderDetailDAO;
        private ObservableCollection<OrderDetail> orders;
        
        public OrderDetailManager()
        {
            InitializeComponent();
            orderDetailDAO = new OrderDetailDAO();
            loadOrderDetailData();
           
            
        }

        private void loadOrderDetailData()
        {
            orders = orderDetailDAO.loadAllOrderDetail();
            lsvOrderDetail.ItemsSource = orders;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = txtFilter.Text.Trim();
            FilterSupplierData(searchTerm);
        }
        private void FilterSupplierData(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                lsvOrderDetail.ItemsSource = orders;
            }
            else
            {
                var filteredOrder = orders.Where(x => x.OrderDetailId.ToString().Contains(searchTerm)).ToList();
                lsvOrderDetail.ItemsSource = filteredOrder;
            }
        }

        private void dtpChonNgay_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var sortList = orderDetailDAO.SortOrderDetailsByDate();
            lsvOrderDetail.ItemsSource = sortList;
        }

        //private void btnChitiet_Click(object sender, RoutedEventArgs e)
        //{
        //    Button btnDetail = (Button)sender;
        //    OrderDetail orderDetail = btnDetail.DataContext as OrderDetail;
        //    if (orderDetail != null)
        //    {
        //        Checkout checkout = new Checkout(new OrderDetailWrapper(orderDetail));
        //        checkout.ShowDialog();
        //    }
        //    else
        //    {
        //      
        //    }

        //}


    }
}
