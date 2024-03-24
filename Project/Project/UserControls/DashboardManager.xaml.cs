using LiveCharts;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using Project.DAO;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.UserControls
{
    /// <summary>
    /// Interaction logic for DashboardManager.xaml
    /// </summary>
    public partial class DashboardManager : UserControl, INotifyPropertyChanged
    {
        private SeriesCollection seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get { return seriesCollection; }
            set
            {
                seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection));
            }
        }

        private ObservableCollection<string> labels;
        public ObservableCollection<string> Labels
        {
            get { return labels; }
            set
            {
                labels = value;
                OnPropertyChanged(nameof(Labels));
            }
        }

      

        private PRN221_Project_HE153685Context dbContext = new PRN221_Project_HE153685Context();
        private OrderDetailDAO orderDetailDAO;
        private PurchaseOrderDAO purchaseOrderDAO;
        private BookDAO bookDAO;

        public DashboardManager()
        {
            InitializeComponent();

            orderDetailDAO = new OrderDetailDAO();
            bookDAO = new BookDAO();
            purchaseOrderDAO = new PurchaseOrderDAO();
            SeriesCollection = new SeriesCollection();
            Labels = new ObservableCollection<string>();
            DataContext = this;
            LoadDashboard();
            for (int year = 2021; year <= DateTime.Now.Year; year++)
            {
                cmbYear.Items.Add(year);
            }
            cmbYear.SelectedItem = DateTime.Now.Year;
        }

        void LoadDashboard()
        {
            decimal totalBookAmount = bookDAO.GetTotalBookPrice();
            decimal totalOrderDetailAmount = orderDetailDAO.GetTotalOrderDetailAmount();

            
            txbTotalMoney.Text = totalBookAmount.ToString();
            txbOrder.Text = totalOrderDetailAmount.ToString();
          
            DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1); 
            DateTime endDate = DateTime.Now; 

            List<string> monthLabels = new List<string>();
            List<double> orderDetailAmounts = orderDetailDAO.GetMonthlyOrderDetailAmounts(startDate, endDate).ToList();
          
            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                monthLabels.Add(currentDate.ToString("MMMM")); 
                currentDate = currentDate.AddMonths(1); 
            }

            
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Tổng tiền bán sản phẩm",
                    Values = new ChartValues<double>(orderDetailAmounts),
                },
                
               
            };
            Labels = new ObservableCollection<string>(monthLabels);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cmbYear.SelectedItem != null)
            {
                int selectedYear = (int)cmbYear.SelectedItem;
                DateTime startDate = new DateTime(selectedYear, 1, 1);
                DateTime endDate;
                if (selectedYear == DateTime.Now.Year)
                {
                    endDate = DateTime.Now;
                }
                else
                {
                    endDate = new DateTime(selectedYear, 12, 31);
                }

                List<string> monthLabels = new List<string>();
                List<double> orderDetailAmounts = orderDetailDAO.GetMonthlyOrderDetailAmounts(startDate, endDate).ToList();

                DateTime currentDate = startDate;
                while (currentDate <= endDate)
                {
                    monthLabels.Add(currentDate.ToString("MMMM"));
                    currentDate = currentDate.AddMonths(1);
                }

                SeriesCollection[0].Values = new ChartValues<double>(orderDetailAmounts);
                Labels = new ObservableCollection<string>(monthLabels);
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;
          protected virtual void OnPropertyChanged(string propertyName)
          {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          }
    }
}
